using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class CommentEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Body { get; set; }
        public virtual UserProfileEntity UserProfile { get; set; }
        public virtual RequestEntity Request { get; set; }
    }
}
    