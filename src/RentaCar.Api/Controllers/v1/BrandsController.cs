using Microsoft.AspNetCore.Mvc;

namespace RentaCar.Api.Controllers.v1
{
    public class BrandsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
