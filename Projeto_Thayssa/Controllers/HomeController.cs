using Microsoft.AspNetCore.Mvc;

namespace Projeto_Thayssa.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
