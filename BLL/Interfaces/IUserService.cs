using API_Contracts.Models.UserModels;
using BLL.Infrastructure;
using DAL.Entities;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<OperationDetails> CreateAsync(RegisterModel model);
        Task<OperationDetails> SignInAsync(LoginModel model);
        Task<OperationDetails> UpdateAsync(UserInfoModel model);
        Task<OperationDetails> DeleteUserAsync();
        Task SignOutAsync();
        Task<ProfileModel> GetProfileModelAsync();
        Task<UserProfileEntity> GetUserProfileEntityAsync();
        Task<ApplicationUserEntity> GetApplicationUserAsync();
        Task<OperationDetails> ChangePasswordAsync(PasswordModel model);
        Task<UserInfoModel> GetPersonalInfoAsync();




    }
}
