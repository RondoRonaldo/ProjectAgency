using DAL.Entities;
using DAL.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {

        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        SignInManager<ApplicationUserEntity> SignInManager { get; }
        IRepository<RequestEntity> RequestRepository { get; }
        IRepository<UserProfileEntity> UserProfileRepository { get; }      
        IRepository<CommentEntity> CommentRepository { get; }      
        IRepository<DistrictEntity> DistrictRepository { get; }
        Task SaveAsync();
    }
}
