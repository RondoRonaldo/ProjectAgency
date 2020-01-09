using API_Contracts.Models.UserModels;
using DAL.Entities;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    /// <summary>
    /// User identity service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Create and save new user
        /// </summary>
        /// <param name="model">User to be created</param>
        Task CreateAsync(RegisterModel model);

        /// <summary>
        /// Sign user in
        /// </summary>
        /// <param name="model">User to be signed in</param>
        Task SignInAsync(LoginModel model);

        /// <summary>
        /// Update existing user
        /// </summary>
        /// <param name="model">User to be updated</param>
        Task UpdateAsync(UserInfoModel model);

        /// <summary>
        /// Delete current user
        /// </summary>
        Task DeleteUserAsync();

        /// <summary>
        /// Sign user out
        /// </summary>
        Task SignOutAsync();

        /// <summary>
        /// Get information of current user 
        /// </summary>
        /// <returns>Profile model</returns>
        Task<ProfileModel> GetProfileModelAsync();

        /// <summary>
        /// Get profile of current user 
        /// </summary>
        /// <returns>Profile entity</returns>
        Task<UserProfileEntity> GetUserProfileEntityAsync();

        /// <summary>
        /// Get application user of current user 
        /// </summary>
        /// <returns>Application user entity</returns>
        Task<ApplicationUserEntity> GetApplicationUserAsync();

        /// <summary>
        /// Change user password
        /// </summary>
        /// <param name="model">Password model</param>
        Task ChangePasswordAsync(PasswordModel model);

        /// <summary>
        /// Get personal information
        /// </summary>
        /// <returns>User info model</returns>
        Task<UserInfoModel> GetPersonalInfoAsync();




    }
}
