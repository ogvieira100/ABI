using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.MessageBus.Models.Integration
{
   public class ProductsIntegrationEvent:IntegrationEvent
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }

        public decimal? Price { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }

        public decimal? Rate { get; set; }

        public int? Count { get; set; }

    }
}
