using System.ComponentModel.DataAnnotations;

namespace API_Contracts.Models.DistrictModels
{
    public class DistrictModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]

        public string Name { get; set; }
    }
}