using EasyPos.Utils;
using Microsoft.AspNetCore.Mvc;

namespace EasyPos.Controllers
{
    public class ReportesController : Controller
    {
        private readonly SessionHelper _sessionHelper;
        public ReportesController(SessionHelper sessionHelper)
        {
            _sessionHelper = sessionHelper ?? throw new ArgumentNullException(nameof(sessionHelper));
        }
        public IActionResult Index()
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("Reportería");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Factura");
            if (acceso)
            {
                return View();
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }
    }
}
