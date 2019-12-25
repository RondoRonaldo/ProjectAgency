using System.Collections.Generic;
using System.Threading.Tasks;
using API_Contracts.Models.DistrictModels;
using BLL.Infrastructure;

namespace BLL.Interfaces
{
    public interface IDistrictService
    {
        Task<OperationDetails> CreateAsync(DistrictModel model);
        Task<OperationDetails> UpdateAsync(DistrictDashboardModel model);
        Task<OperationDetails> RemoveAsync(string id);
        Task<List<DistrictDashboardModel>> GetAsync();
    }
}
