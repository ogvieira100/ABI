using DeveloperEvaluation.Core.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeveloperEvaluation.CartsApi.Models
{

    public enum StatusCartsEn
    { 
           Canceled = 1,
           NotCanceled = 2
    }


    public class Carts : BaseEntity
    {
        public Guid UserIdInsert { get; set; }
        public virtual List<CartsItens> CartsItens { get; set; }
        public DateTime? DateOfSale { get; set; }
        public StatusCartsEn StatusCartsEn { get; set; }

        public Carts()
        {
            StatusCartsEn = StatusCartsEn.NotCanceled;
            CartsItens = new List<CartsItens>();
        }
    }
}
