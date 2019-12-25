using System.ComponentModel.DataAnnotations;

namespace API_Contracts.Models.CommentModels
{
    public class CommentModel
    {
        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string Body { get; set; }

        [Required]
        public string RequestId { get; set; }
    }
}