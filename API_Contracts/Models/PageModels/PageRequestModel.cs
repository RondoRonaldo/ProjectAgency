using System.ComponentModel.DataAnnotations;

namespace API_Contracts.Models.PageModels
{
    public interface IPageRequestModel<out T>
    {
        T Request { get; }
        int PageSize { get; set; }
        int PageIndex { get; set; }
    }

    public class PageRequestModel<T> : IPageRequestModel<T>
    {
        public T Request { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }
    }
}