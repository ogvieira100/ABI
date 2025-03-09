using DeveloperEvaluation.Core.Domain;

namespace DeveloperEvaluation.CartsApi.Models
{
    public class CartsItens : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal UnitPrices { get; set; }
        public decimal? Discounts { get; set; }
        public Guid ProductId { get; set; }
        public virtual Products Product { get; set; }
        public Guid CartsId { get; set; }
        public virtual Carts Carts { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime? DateUpdated { get; set; }

        public CartsItens()
        {
            DateAdd = new DateTime();
        }
    }
}
