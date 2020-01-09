using API_Contracts.Models.Filters;
using API_Contracts.Models.RequestModels;
using System.Threading.Tasks;
using API_Contracts.Models.PageModels;

namespace BLL.Interfaces
{
    /// <summary>
    /// Request service
    /// </summary>
    public interface IRequestService
    {
        /// <summary>
        /// Get requests 
        /// </summary>
        /// <returns>page with requests</returns>
        Task<PageResponseModel<RequestDashboardModel>> GetUserRequestsAsync();

        /// <summary>
        /// Creates new request and saves it
        /// </summary>
        /// <param name="requestModel">Request model</param>
        Task CreateAsync(RequestModel requestModel);

        /// <summary>
        /// Get request by id
        /// </summary>
        /// <param name="id">Request identifier</param>
        /// <returns>Request with certain id</returns>
        Task<RequestDashboardModel> GetAsync(string id);

        /// <summary>
        /// Update request 
        /// </summary>
        /// <param name="model">Model to update</param>
        Task UpdateAsyncAsUser(RequestUpdateModel model);

        /// <summary>
        /// Update any request 
        /// </summary>
        /// <param name="model">Request to update</param>
        Task UpdateAsyncAsAdmin(RequestUpdateModel model);

        /// <summary>
        /// Remove request 
        /// </summary>
        /// <param name="id">Request to delete</param>
        Task RemoveAsyncAsUser(string id);

        /// <summary>
        /// Remove any request 
        /// </summary>
        /// <param name="id">Model to delete</param>
        Task RemoveAsAdminAsync(string id);

        /// <summary>
        /// Get requests with extended filter
        /// </summary>
        /// <param name="model">Information about page and filter to be used</param>
        /// <returns>Page model with filtered requests</returns>
        Task<PageResponseModel<RequestDashboardModel>> AdminSearch(PageRequestModel<AdminFilterModel> model);

        /// <summary>
        /// Get requests with filter
        /// </summary>
        /// <param name="model">Information about page and filter to be used</param>
        /// <returns>Page model with filtered requests</returns>
        Task<PageResponseModel<RequestDashboardModel>> UserSearch(PageRequestModel<UserFilterModel> model);

        /// <summary>
        /// Get details of certain request 
        /// </summary>
        /// <param name="id">Request id</param>
        /// <returns>Request model with comments to it</returns>
        Task<RequestDetailsModel> GetRequestDetailsAsync(string id);

        /// <summary>
        /// Moderate request
        /// </summary>
        /// <param name="model">Moderation information</param>
        Task ModerateRequestAsync(RequestModerationModel model);
    }
}
