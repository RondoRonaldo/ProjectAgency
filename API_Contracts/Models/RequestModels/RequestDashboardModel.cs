using System;
using API_Contracts.Models.UserModels;

namespace API_Contracts.Models.RequestModels
{
    public class RequestDashboardModel : RequestModel
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
        public UserInfoModel UserInfo { get; set; }
    }
}