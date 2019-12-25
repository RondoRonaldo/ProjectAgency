namespace API_Contracts.Models.Filters
{
    public class AdminFilterModel : UserFilterModel
    {
        public bool? IsModerated { get; set; }
        public bool? IsAccepted { get; set; }
    }
}