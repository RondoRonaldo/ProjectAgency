namespace API_Contracts.Models.UserModels
{
    public class ProfileModel : UserInfoModel
    {
        public string Role { get; set; }
        public string Email { get; set; }
    }
}