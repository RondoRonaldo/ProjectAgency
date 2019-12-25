using System;
using System.Collections.Generic;
using API_Contracts.Models.CommentModels;
using API_Contracts.Models.UserModels;

namespace API_Contracts.Models.RequestModels
{
    public class RequestDetailsModel : RequestModel
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
        public UserInfoModel UserInfo { get; set; }
        public IEnumerable<CommentDashboardModel> Comments { get; set; }
    }
}