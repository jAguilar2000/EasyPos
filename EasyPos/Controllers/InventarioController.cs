using EasyPos.Models;
using EasyPos.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Controllers
{
    public class InventarioController : Controller
    {
        private readonly EasyPosDb db;
        private readonly SessionHelper _sessionHelper;
        public InventarioController(EasyPosDb db, SessionHelper sessionHelper)
        {
            this.db = db;
            _sessionHelper = sessionHelper ?? throw new ArgumentNullException(nameof(sessionHelper));
        }
        public async Task<IActionResult> Index()
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Inventario");
            if (acceso)
            {
                ViewBag.productoId = new SelectList(db.Producto.Where(x => x.Estado == true), "ProductoId", "Descripcion");
                return View(await db.Inventario.Include(x => x.Producto).ToListAsync());
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

        public ActionResult Create()
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Inventario");
            if (acceso)
            {
                return View();
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inventario inventario)
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Inventario");
            if (acceso)
            {
                if (ModelState.IsValid)
                {
                    inventario.Estado = true;
                    db.Inventario.Add(inventario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(inventario);
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

        public ActionResult Edit(int? id)
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Inventario");
            if (acceso)
            {
                if (id == null)
                {
                    return BadRequest();
                }
                Inventario inventario = db.Inventario.Find(id);
                if (inventario == null)
                {
                    return NotFound();
                }
                ViewBag.productoId = new SelectList(db.Producto.Where(x => x.Estado == true), "ProductoId", "Descripcion", inventario.ProductoId);
                return View(inventario);
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Inventario inventario)
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Inventario");
            if (acceso)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(inventario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(inventario);
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }
    }
}
