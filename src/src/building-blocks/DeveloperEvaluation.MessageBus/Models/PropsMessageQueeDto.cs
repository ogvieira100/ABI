using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.MessageBus.Models
{
    public class PropsMessageQueeDto
    {
        public string Queue { get; set; } = "";
        public bool Durable { get; set; } = true;
        public bool Exclusive { get; set; } = false;
        public bool AutoDelete { get; set; } = false;
        public IDictionary<string, object> Arguments { get; set; } = new Dictionary<string, object>();
        /*5 min*/
        public int TimeoutMensagem { get; set; } = 300000;


    }
}
