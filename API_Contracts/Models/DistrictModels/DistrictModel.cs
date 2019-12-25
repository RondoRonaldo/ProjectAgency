using System.ComponentModel.DataAnnotations;

namespace API_Contracts.Models.DistrictModels
{
    public class DistrictModel
    {
        [Required] public string Name { get; set; }
    }
}