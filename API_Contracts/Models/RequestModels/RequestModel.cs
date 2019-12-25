using System.ComponentModel.DataAnnotations;

namespace API_Contracts.Models.RequestModels
{
    public class RequestModel
    {
        [Required]
        [StringLength(40, MinimumLength = 10)]
        public string Header { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Body { get; set; }

        [Required] 
        [Range(1, int.MaxValue)] 
        public int Square { get; set; }

        [Required] 
        [Range(1, int.MaxValue)]
        public int NumberOfRooms { get; set; }

        [Required]
        public string District { get; set; }

        public bool IsForRent { get; set; }
    }
}