using API_Contracts.Models.CommentModels;
using BLL.Infrastructure;
using System.Threading.Tasks;
using API_Contracts.Models.PageModels;
using API_Contracts.Models.RequestModels;

namespace BLL.Interfaces
{
    public interface ICommentService
    {
        Task<CommentDashboardModel> CreateAsync(CommentModel model);
        Task<PageResponseModel<RequestDetailsModel>> GetUserRequestsOffersWithRequests();

        Task<OperationDetails> RemoveAsAdminAsync(string id);
        Task<OperationDetails> RemoveAsUserAsync(string id);

    }
}
