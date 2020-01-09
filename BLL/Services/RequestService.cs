using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Contracts.Models.Filters;
using API_Contracts.Models.PageModels;
using API_Contracts.Models.RequestModels;
using AutoMapper;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class RequestService : IRequestService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IUserService _userService;

        public RequestService(IUnitOfWork uow, IMapper mapper, IUserService userService)
        {
            _uow = uow;
            _mapper = mapper;
            _userService = userService;
        }


        public async Task CreateAsync(RequestModel requestModel)
        {
            var district = (await _uow.DistrictRepository.FindAsync(exp => exp.Name == requestModel.District))
                .FirstOrDefault();
            if (district == null)
            {
                throw new ArgumentNullException(nameof(district));
            }
            var userProfile = await _userService.GetUserProfileEntityAsync();
            var request = _mapper.Map<RequestModel, RequestEntity>
            (requestModel, opt => opt.AfterMap
            ((src, dest) =>
            {
                dest.UserProfile = userProfile;
                dest.District = district;
            }
            ));

            await _uow.RequestRepository.CreateAsync(request);
            await _uow.SaveAsync();
        }


        public async Task<PageResponseModel<RequestDashboardModel>> GetUserRequestsAsync()
        {
            var userProfile = await _userService.GetUserProfileEntityAsync();
            var requests = await _uow.RequestRepository.FindAsync(exp => exp.UserProfile.Id == userProfile.Id);
            var result = _mapper.Map<IEnumerable<RequestDashboardModel>>(requests);
            var model = new PageResponseModel<RequestDashboardModel>(result, requests.Count());
            return model;
        }


        public async Task<RequestDetailsModel> GetRequestDetailsAsync(string id)
        {
            var request = await _uow.RequestRepository.GetAsync(id);
            var model = _mapper.Map<RequestDetailsModel>(request);
            return model;
        }


        public async Task<RequestDashboardModel> GetAsync(string id)
        {
            var result = await _uow.RequestRepository.GetAsync(id);
            return _mapper.Map<RequestDashboardModel>(result);
        }

        public async Task RemoveAsAdminAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
              throw new ArgumentNullException(nameof(id));
            }

            var result = await _uow.RequestRepository.GetAsync(id);
            await RemoveAsync(result);
        }

        public async Task RemoveAsyncAsUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var result = await _uow.RequestRepository.GetAsync(id);
            
                if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            if (result.UserProfile.Id != (await _userService.GetUserProfileEntityAsync()).Id)
            {
                throw new ArgumentException();
            }

            await RemoveAsync(result);
        }

        public async Task UpdateAsyncAsUser(RequestUpdateModel model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));

            if ((await _userService.GetUserProfileEntityAsync()).Id != model.Id) 
            {
                throw new ArgumentException();
            }
            await UpdateAsync(model);
        }

        public async Task UpdateAsyncAsAdmin(RequestUpdateModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await UpdateAsync(model);
        }


        public async Task<PageResponseModel<RequestDashboardModel>> AdminSearch(
            PageRequestModel<AdminFilterModel> model)
        {
            var result = _uow.RequestRepository.GetAllAsQueryable();

            if (model.Request.IsModerated != null)
            {
                result = result.Where(exp => exp.IsModerated == model.Request.IsModerated);
            }

            if (model.Request.IsAccepted != null)
            {
                result = result.Where(exp => exp.IsAccepted == model.Request.IsAccepted);
            }

            return await Search(result, model);
        }

        public async Task<PageResponseModel<RequestDashboardModel>> UserSearch(PageRequestModel<UserFilterModel> model)
        {
            var result = _uow.RequestRepository.GetAllAsQueryable();
            result = result.Where(exp => exp.IsAccepted && exp.IsModerated);
            return await Search(result, model);
        }
        
        private async Task<PageResponseModel<RequestDashboardModel>> Search(IQueryable<RequestEntity> result,
            IPageRequestModel<UserFilterModel> model)
        {
            if (model.Request.SquareFrom != null)
            {
                result = result.Where(exp => exp.Square >= model.Request.SquareFrom);
            }

            if (model.Request.SquareTo != null)
            {
                result = result.Where(exp => exp.Square <= model.Request.SquareTo);
            }

            if (model.Request.NumberOfRoomsFrom != null)
            {
                result = result.Where(exp => exp.NumberOfRooms >= model.Request.NumberOfRoomsFrom);
            }

            if (model.Request.NumberOfRoomsTo != null)
            {
                result = result.Where(exp => exp.NumberOfRooms <= model.Request.NumberOfRoomsTo);
            }

            if (model.Request.DateFrom != null)
            {
                result = result.Where(exp => exp.CreationDate >= model.Request.DateFrom);
            }

            if (model.Request.DateTo != null)
            {
                result = result.Where(exp => exp.CreationDate >= model.Request.DateTo);
            }

            if (model.Request.IsForRent != null)
            {
                result = result.Where(exp => exp.IsForRent == model.Request.IsForRent);
            }

            if (!string.IsNullOrEmpty(model.Request.District))
            {
                result = result.Where(exp => exp.District.Name == model.Request.District);
            }

            var resultsPerPage = await result.Page(model.PageIndex, model.PageSize);
            return new PageResponseModel<RequestDashboardModel>(
                _mapper.Map<IEnumerable<RequestDashboardModel>>(resultsPerPage), result.Count());
        }

        private async Task RemoveAsync(RequestEntity result)
        {
            _uow.RequestRepository.Remove(result);
            await _uow.SaveAsync();
        }

        private async Task UpdateAsync(RequestUpdateModel model)
        {
            var result = _mapper.Map<RequestEntity>(model);
            _uow.RequestRepository.Update(result);
            await _uow.SaveAsync();
        }

        public async Task ModerateRequestAsync(RequestModerationModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.RequestId))
            {
                throw new ArgumentNullException(nameof(model.RequestId));
            }

            var request = await _uow.RequestRepository.GetAsync(model.RequestId);
            request.IsAccepted = model.IsAccepted;
            request.IsModerated = true;
            _uow.RequestRepository.Update(request);
            await _uow.SaveAsync();
        }



    }




}