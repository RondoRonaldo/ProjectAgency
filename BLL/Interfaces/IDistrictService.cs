using System.Collections.Generic;
using System.Threading.Tasks;
using API_Contracts.Models.DistrictModels;
using BLL.Infrastructure;

namespace BLL.Interfaces
{
    /// <summary>
    /// District manager service
    /// </summary>
    public interface IDistrictService
    {
        /// <summary>
        /// Create new district and saves it
        /// </summary>
        /// <param name="model">district model</param>
        Task CreateAsync(DistrictModel model);

        /// <summary>
        /// Update district 
        /// </summary>
        /// <param name="model">District to be updated</param>
        Task UpdateAsync(DistrictDashboardModel model);

        /// <summary>
        /// Remove district
        /// </summary>
        /// <param name="id">District id</param>
        Task RemoveAsync(string id);

        /// <summary>
        /// Get all districts 
        /// </summary>
        /// <returns>List of districts</returns>
        Task<List<DistrictDashboardModel>> GetAsync();
    }
}
