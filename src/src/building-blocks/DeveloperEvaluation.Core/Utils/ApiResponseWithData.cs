using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.Core.Utils
{

    public class ApiResponseWithData<T> : ApiResponse
    {
        public T? Data { get; set; }
    }
}
