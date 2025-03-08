using System.Reflection;

namespace DeveloperEvaluation.ProductsApi.ValueObjects
{
    public class RattingValueObjects
    {
        public decimal? Rate { get; set; }
        public int? Count { get; set; }

        protected RattingValueObjects()
        {
            
        }
    }
}
