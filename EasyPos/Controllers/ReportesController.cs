using EasyPos.Models;
using EasyPos.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Controllers
{
    public class ReportesController : Controller
    {
        private readonly SessionHelper _sessionHelper;
        private readonly EasyPosDb db;
        public ReportesController(SessionHelper sessionHelper, EasyPosDb _db)
        {
            this.db = _db;
            _sessionHelper = sessionHelper ?? throw new ArgumentNullException(nameof(sessionHelper));
        }
        public IActionResult Index()
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Reportería");
            if (acceso)
            {
                return View();
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

        public async Task< IActionResult> IndexProducto()
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Reportería");
            if (acceso)
            {
                var list = await db.Producto.Include(x => x.CategoriaProducto).ToListAsync();
                return View(list);
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

        public async Task<IActionResult> IndexCliente()
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Reportería");
            if (acceso)
            {
                var list = await db.Cliente.ToListAsync();
                return View(list);
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

        public async Task<IActionResult> IndexVentas()
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Reportería");
            if (acceso)
            {
                var list = await db.Factura.Include(x =>x.Cliente).ToListAsync();
                return View(list);
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }
        public async Task<IActionResult> IndexProveedores()
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Reportería");
            if (acceso)
            {
                var list = await db.Proveedor.ToListAsync();
                return View(list);
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }
    }
}
