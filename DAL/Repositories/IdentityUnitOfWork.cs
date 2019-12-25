using DAL.EF;
using DAL.Entities;
using DAL.Identity;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IdentityUnitOfWork(ApplicationContext context, ApplicationUserManager userManager,
         ApplicationRoleManager roleManager, SignInManager<ApplicationUserEntity> signInManager)
        {
            _context = context;
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;

            RequestRepository = new RequestRepository(context);
            UserProfileRepository = new UserProfileRepository(context);
            CommentRepository = new CommentRepository(context);
            DistrictRepository = new DistrictRepository(context);

        }

        public ApplicationUserManager UserManager { get; }
        public IRepository<UserProfileEntity> UserProfileRepository { get; }
        public ApplicationRoleManager RoleManager { get; }
        public SignInManager<ApplicationUserEntity> SignInManager { get; }
        public IRepository<RequestEntity> RequestRepository { get; }

        public IRepository<CommentEntity> CommentRepository { get; }
        public  IRepository<DistrictEntity> DistrictRepository { get; }
        
        public void Dispose()
        {
            _context.Dispose();
            UserManager.Dispose();
            RoleManager.Dispose();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
