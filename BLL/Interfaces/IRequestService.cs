using API_Contracts.Models.Filters;
using API_Contracts.Models.RequestModels;
using BLL.Infrastructure;
using System.Threading.Tasks;
using API_Contracts.Models.PageModels;

namespace BLL.Interfaces
{
    public interface IRequestService
    {
        Task<PageResponseModel<RequestDashboardModel>> GetUserRequestsAsync();
        Task<OperationDetails> CreateAsync(RequestModel requestModel);
        Task<RequestDashboardModel> GetAsync(string id);
        Task<OperationDetails> UpdateAsyncAsUser(RequestUpdateModel model);
        Task<OperationDetails> UpdateAsyncAsAdmin(RequestUpdateModel model);
        Task<OperationDetails> RemoveAsyncAsUser(string id);
        Task<OperationDetails> RemoveAsAdminAsync(string id);
        Task<PageResponseModel<RequestDashboardModel>> AdminSearch(PageRequestModel<AdminFilterModel> model);
        Task<PageResponseModel<RequestDashboardModel>> UserSearch(PageRequestModel<UserFilterModel> model);
        Task<RequestDetailsModel> GetRequestDetailsAsync(string id);
        Task<OperationDetails> ModerateRequestAsync(RequestModerationModel model);
    }
}
