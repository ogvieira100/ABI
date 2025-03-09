using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeveloperEvaluation.CartsApi.Application.UpdateCartsItens
{
    public class UpdateCartsItensUnitPriceCommand:IRequest<UpdateCartsItensUnitPriceResult>
    {
        public decimal UnitPrice { get; set; }

        public Guid ProductId { get; set; }

    }
}
