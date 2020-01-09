using API_Contracts.Models.CommentModels;
using BLL.Infrastructure;
using System.Threading.Tasks;
using API_Contracts.Models.PageModels;
using API_Contracts.Models.RequestModels;

namespace BLL.Interfaces
{
    /// <summary>
    /// Comment service
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// Create new comment and saves it
        /// </summary>
        /// <param name="model">comment model</param>
        /// <returns>new comment</returns>
        Task<CommentDashboardModel> CreateAsync(CommentModel model);

        /// <summary>
        /// Remove comment anyone's user
        /// </summary>
        /// <param name="id">comment id</param>
        Task RemoveAsAdminAsync(string id);

        /// <summary>
        /// Remove  user comment
        /// </summary>
        /// <param name="id">comment id</param>
        Task RemoveAsUserAsync(string id);

    }
}
