using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class ApplicationUserEntity : IdentityUser 
    {
        public virtual UserProfileEntity UserProfile { get; set; }

    }
}
