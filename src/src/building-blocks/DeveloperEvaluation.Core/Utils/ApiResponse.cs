using DeveloperEvaluation.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.Core.Utils
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public IEnumerable<ValidationErrorDetail> Errors { get; set; } = [];
    }
}
