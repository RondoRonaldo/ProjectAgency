using API_Contracts.Models.CommentModels;
using AutoMapper;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Contracts.Models.PageModels;
using API_Contracts.Models.RequestModels;

namespace BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IUserService _userService;

        public CommentService(IMapper mapper, IUnitOfWork unitOfWork, IUserService userService)
        {
            _mapper = mapper;
            _uow = unitOfWork;
            _userService = userService;
        }

        public async Task<CommentDashboardModel> CreateAsync(CommentModel model)
        {

            var userProfile = await _userService.GetUserProfileEntityAsync();
            var request = await _uow.RequestRepository.GetAsync(model.RequestId);
            var result = _mapper.Map<CommentModel, CommentEntity>(model, opt => opt.AfterMap
                 ((src, dest) =>
                 {
                     dest.UserProfile = userProfile;
                     dest.Request = request;
                 })
                 );

            var entity = await _uow.CommentRepository.CreateAsync(result);
            await _uow.SaveAsync();

            return _mapper.Map<CommentDashboardModel>(entity);
        }


        public async Task<PageResponseModel<RequestDetailsModel>> GetUserRequestsOffersWithRequests()
        {
            var currentUser = await _userService.GetUserProfileEntityAsync();
            var requestOffers = await _uow.CommentRepository.FindAsync(exp => exp.UserProfile.Id == currentUser.Id);
            var result = _mapper.Map<IEnumerable<RequestDetailsModel>>(requestOffers);

            return new PageResponseModel<RequestDetailsModel>(_mapper.Map<IEnumerable<RequestDetailsModel>>(result),
                result.Count());
        }

        //public async Task<Comment> GetAsync(string id)
        //{
        //    var entity = await _uow.CommentRepository.GetAsync(id);
        //    return _mapper.Map<RequestOfferDto>(entity);
        //}

        //public Task<OperationDetails> RemoveAsAdminAsync(string id)
        //{
        //    throw new NotImplementedException();
        //}

        private async Task<OperationDetails> RemoveAsync(CommentEntity entity)
        {
            _uow.CommentRepository.Remove(entity);
            await _uow.SaveAsync();

            return new OperationDetails(true, "Request offer was deleted", string.Empty);
        }

        public async Task<OperationDetails> RemoveAsAdminAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                // TODO: throw ArgumentEx("")
                return new OperationDetails(false, "Request offer id doesn't exist", string.Empty);
            }

            var result = await _uow.CommentRepository.GetAsync(id);

            return await RemoveAsync(result);
        }
        public async Task<OperationDetails> RemoveAsUserAsync(string id)
        {

            var result = await _uow.CommentRepository.GetAsync(id);  
            if (result == null)
            {
                return new OperationDetails(false, "Request offer id doesn't exist", string.Empty);
            }
            if (result.UserProfile.Id != (await _userService.GetUserProfileEntityAsync()).Id)
            {
                return new OperationDetails(false, "Permission denied", string.Empty);
            }
            return await RemoveAsync(result);
        }

        //public PageModel<RequestOfferDashboardModel> Search(string query, int pageIndex, int pageSize)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<OperationDetails> UpdateAsync(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<OperationDetails> UpdateAsyncAsAdmin(string id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
