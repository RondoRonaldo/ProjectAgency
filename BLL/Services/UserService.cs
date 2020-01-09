using System;
using API_Contracts.Models.UserModels;
using AutoMapper;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Castle.Core.Internal;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _uow = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserProfileEntity> GetUserProfileEntityAsync()
        {
            var id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (id.IsNullOrEmpty())
            {
                throw new ArgumentNullException();
            }
            return await _uow.UserProfileRepository.GetAsync(id);
        }

        public async Task<ApplicationUserEntity> GetApplicationUserAsync()
        {
            var id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _uow.UserManager.FindByIdAsync(id);
        }

        public async Task<ProfileModel> GetProfileModelAsync()
        {
            var profile = await GetUserProfileEntityAsync();            
            var userRole = (await _uow.UserManager.GetRolesAsync(profile.ApplicationUser)).FirstOrDefault();
            var result = _mapper.Map<UserProfileEntity,ProfileModel>(profile,opt=> opt.AfterMap((src, dest) =>
            { dest.Role = userRole; }));
            return result;
        }

        public async Task<UserInfoModel> GetPersonalInfoAsync()
        {
           var user =  await GetUserProfileEntityAsync();
            return _mapper.Map<UserInfoModel>(user);
        }

        public async Task CreateAsync(RegisterModel model)
        {

            if ((await _uow.RoleManager.FindByNameAsync("admin")) == null)
            {
                var role1 = new IdentityRole { Name = "admin" };
                var role2 = new IdentityRole { Name = "user" };
                await _uow.RoleManager.CreateAsync(role2);
                await _uow.RoleManager.CreateAsync(role1);

                var userIdentity1 = new ApplicationUserEntity { Email = "Admin@ukr.net", UserName = "Admin@ukr.net" };
                var userProfile1 = new UserProfileEntity();
                userIdentity1.UserProfile = userProfile1;

                await _uow.UserManager.CreateAsync(userIdentity1, "Nrj29fkjkkmfk3");
                await _uow.UserManager.AddToRoleAsync(userIdentity1, "admin");

                await _uow.SaveAsync();
            }

            var user = await _uow.UserManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                throw new ArgumentException("Email is already used");
            }

            var userIdentity = new ApplicationUserEntity
            {
                Email = model.Email,
                UserName = model.Email,
                UserProfile = _mapper.Map<UserProfileEntity>(model)
            }; 

            await _uow.UserManager.CreateAsync(userIdentity, model.Password); 
            await _uow.UserManager.AddToRoleAsync(userIdentity, "user");
            await _uow.SaveAsync();
            var logInModel = _mapper.Map<LoginModel>(model);
            await SignInAsync(logInModel);
        }

        public async Task UpdateAsync(UserInfoModel model)
        {
            if (model == null) 
            {
                throw new ArgumentNullException(nameof(model));
            }
            var user = await GetUserProfileEntityAsync();
            user = _mapper.Map(model, user); 
            _uow.UserProfileRepository.Update(user);
            await _uow.SaveAsync();
        }

        public async Task SignInAsync(LoginModel model)
        {
            var result = await _uow.SignInManager.PasswordSignInAsync(model.Email, model.Password, model.IsPersistent, false);
            if (result == SignInResult.Failed)
            {
                throw new ArgumentException("Incorrect username and/or password");
            }
        }

        public async Task SignOutAsync()
        {
            await _uow.SignInManager.SignOutAsync();
        }

        public async Task DeleteUserAsync()
        {
            var user = await GetApplicationUserAsync(); 
            await _uow.UserManager.DeleteAsync(user);
            await _uow.SaveAsync();

        }

        public async Task ChangePasswordAsync(PasswordModel model)
        {
            var user = await GetApplicationUserAsync();
            await _uow.UserManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            await _uow.SaveAsync();
        }
    }
}
