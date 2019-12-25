using System.Collections.Generic;

namespace API_Contracts.Models.PageModels
{
    public class PageResponseModel<T>
    {
        public PageResponseModel(IEnumerable<T> list, int totalPages)
        {
            Records = list;
            TotalRecords = totalPages;
        }

        public IEnumerable<T> Records { get; set; }

        public int TotalRecords { get; set; }
    }
}