using DeveloperEvaluation.CartsApi.ValueObjects;
using DeveloperEvaluation.Core.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeveloperEvaluation.CartsApi.Models
{
    public class Products : BaseEntity
    {

        public Guid ProductIdIntegrated { get; set; }
        public string? Title { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public string? Category { get; set; }

        public string? Image { get; set; }

        public RattingValueObjects Ratting { get; set; }

        public virtual IEnumerable<CartsItens> CartsItens { get; set; }

        public Products()
        {
            CartsItens = new List<CartsItens>();
        }
    }
}
