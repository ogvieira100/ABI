using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.Core.Utils
{
    public class PaginatedResponse<T> : ApiResponseWithData<IEnumerable<T>>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
    }
}
