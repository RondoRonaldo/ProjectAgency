using System.ComponentModel.DataAnnotations;

namespace API_Contracts.Models.UserModels
{
    public class UserInfoModel
    {
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}