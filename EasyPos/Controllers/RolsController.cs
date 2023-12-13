using EasyPos.Models;
using EasyPos.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Controllers
{
    public class RolsController : Controller
    {
        private readonly EasyPosDb db;
        private readonly SessionHelper _sessionHelper;

        public RolsController(EasyPosDb db, SessionHelper sessionHelper)
        {
            this.db = db;
            _sessionHelper = sessionHelper ?? throw new ArgumentNullException(nameof(sessionHelper));
        }

        public ActionResult Index()
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Permisos");
            if (acceso)
            {
                return View(db.Rol.ToList());
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
            
        }

        public ActionResult Create()
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Permisos");
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
        public ActionResult Create(Rol rol)
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Permisos");
            if (acceso)
            {
                if (ModelState.IsValid)
                {
                    rol.Estado = true;
                    db.Rol.Add(rol);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(rol);
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

        public ActionResult Edit(int? id)
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Permisos");
            if (acceso)
            {
                if (id == null)
                {
                    return BadRequest();
                }
                Rol rol = db.Rol.Find(id);
                if (rol == null)
                {
                    return NotFound();
                }
                return View(rol);
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Rol rol)
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Permisos");
            if (acceso)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(rol).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(rol);
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

    }
}
