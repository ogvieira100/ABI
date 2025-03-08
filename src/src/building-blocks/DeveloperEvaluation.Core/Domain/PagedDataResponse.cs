using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.Core.Domain
{
    public class PagedDataResponse<T> 
    {
        public List<T> Items { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalItens { get; set; }

        public int TotalPages { get; set; }

        public PagedDataResponse()
        {
            Items = new List<T>();
        }

    }
}
