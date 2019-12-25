using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
   
    public class UserProfileEntity
    {
        [ForeignKey(nameof(ApplicationUser)),
    DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ApplicationUserEntity ApplicationUser { get; set; }
        public virtual ICollection<RequestEntity> Requests { get; set; }
        public virtual ICollection<CommentEntity> Comment { get; set; }
    }
}
