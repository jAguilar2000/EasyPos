using EasyPos.Models;
using EasyPos.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Controllers
{
    public class KardexController : Controller
    {
        private readonly EasyPosDb db;
        private readonly SessionHelper _sessionHelper;
        public KardexController(EasyPosDb db, SessionHelper sessionHelper)
        {
            this.db = db;
            _sessionHelper = sessionHelper ?? throw new ArgumentNullException(nameof(sessionHelper));
        }
        public async Task< IActionResult> Index()
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Inventario");
            if (acceso)
            {
                return View(await db.kardex.ToListAsync());
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }
    }
}
