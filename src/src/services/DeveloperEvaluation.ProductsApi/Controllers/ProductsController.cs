using Microsoft.AspNetCore.Mvc;

namespace DeveloperEvaluation.ProductsApi.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
