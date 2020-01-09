using System;
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
        private async Task RemoveAsync(CommentEntity entity)
        {
            _uow.CommentRepository.Remove(entity);
            await _uow.SaveAsync();
        }

        public async Task RemoveAsAdminAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException();
            }

            var result = await _uow.CommentRepository.GetAsync(id);
            await RemoveAsync(result);
        }
        public async Task RemoveAsUserAsync(string id)
        {

            var result = await _uow.CommentRepository.GetAsync(id);  
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            if (result.UserProfile.Id != (await _userService.GetUserProfileEntityAsync()).Id)
            {
                throw new ArgumentException("Permission denied");
            } 
            await RemoveAsync(result);
        }

    }
}
