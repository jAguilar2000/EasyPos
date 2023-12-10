using Microsoft.AspNetCore.Mvc;

namespace EasyPos.Controllers
{
    public class ReportesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
