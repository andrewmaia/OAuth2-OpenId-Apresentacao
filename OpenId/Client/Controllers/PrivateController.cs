using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MvcClient2.Controllers
{
    [Authorize]
    public class PrivateController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public PrivateController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }
        public IActionResult Index()
        {
            return View();
        }


    }
}