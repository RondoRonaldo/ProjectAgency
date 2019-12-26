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


        public async Task<OperationDetails> CreateAsync(RequestModel requestModel)
        {

            var district = (await _uow.DistrictRepository.FindAsync(exp => exp.Name == requestModel.District))
                .FirstOrDefault();
            if (district == null)
            {
                return new OperationDetails(false, "District was not found", string.Empty);
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
            return new OperationDetails(true, "Created successfully", string.Empty);
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

        public async Task<OperationDetails> RemoveAsAdminAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                // TODO: throw ArgumentEx("")
                return new OperationDetails(false, "Request id doesn't exist", string.Empty);
            }

            var result = await _uow.RequestRepository.GetAsync(id);

            return await RemoveAsync(result);
        }

        public async Task<OperationDetails> RemoveAsyncAsUser(string id)
        {
            var result = await _uow.RequestRepository.GetAsync(id);
            {
                if (result == null) return new OperationDetails(false, "Request id doesn't exist", string.Empty);
            }

            if (result.UserProfile.Id != (await _userService.GetUserProfileEntityAsync()).Id)
            {
                return new OperationDetails(false, "Permission denied", string.Empty);
            }

            return await RemoveAsync(result);
        }

        public async Task<OperationDetails> UpdateAsyncAsUser(RequestUpdateModel model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));

            //if ((await _userService.GetUserProfileEntityAsync()).Id != model.UserProfileId)   - TODO
            //{
            //    return new OperationDetails(false, "Permission denied", string.Empty);
            //}
            return await UpdateAsync(model);
        }

        public async Task<OperationDetails> UpdateAsyncAsAdmin(RequestUpdateModel model)
        {
            if (model == null)
            {
                return new OperationDetails(false, "model is null", string.Empty);
            }

            return await UpdateAsync(model);
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

        private async Task<OperationDetails> RemoveAsync(RequestEntity result)
        {
            _uow.RequestRepository.Remove(result);
            await _uow.SaveAsync();
            return new OperationDetails(true, "Request was deleted", string.Empty);
        }

        private async Task<OperationDetails> UpdateAsync(RequestUpdateModel model)
        {
            var result = _mapper.Map<RequestEntity>(model);
            _uow.RequestRepository.Update(result);
            await _uow.SaveAsync();
            return new OperationDetails(true, "Request was updated", string.Empty);
        }

        public async Task<OperationDetails> ModerateRequestAsync(RequestModerationModel model)
        {
            if (model == null)
            {
                return new OperationDetails(false, "null model", string.Empty);
            }
            if (string.IsNullOrEmpty(model.RequestId))
            {
                return new OperationDetails(false, "Request id is null", string.Empty);
            }

            var request = await _uow.RequestRepository.GetAsync(model.RequestId);
            request.IsAccepted = model.IsAccepted;
            request.IsModerated = true;
            _uow.RequestRepository.Update(request);
            await _uow.SaveAsync();
            return new OperationDetails(true, "request updated", string.Empty);
        }



    }




}