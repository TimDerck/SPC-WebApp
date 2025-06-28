using Microsoft.AspNetCore.Mvc;

namespace SPC.Api.Controllers
{
    public class AccountController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
