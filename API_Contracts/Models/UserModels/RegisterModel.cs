using System.ComponentModel.DataAnnotations;

namespace API_Contracts.Models.UserModels
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress] 
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required] 
        public string PhoneNumber { get; set; }

        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }
    }
}