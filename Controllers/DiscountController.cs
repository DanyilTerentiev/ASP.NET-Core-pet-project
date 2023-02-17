using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskAuthenticationAuthorization.Models;

namespace TaskAuthenticationAuthorization.Controllers
{
    [Authorize(Policy ="BuyerType")]
    public class DiscountController : Controller
    {
        public IActionResult Index()
        {
            return Content("Your discount is 10%");
        }
    }
}
