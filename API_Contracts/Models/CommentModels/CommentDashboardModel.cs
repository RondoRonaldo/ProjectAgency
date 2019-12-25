using API_Contracts.Models.UserModels;

namespace API_Contracts.Models.CommentModels
{
    public class CommentDashboardModel
    {
        public string Body { get; set; }

        public UserInfoModel UserInfo { get; set; }
    }
}