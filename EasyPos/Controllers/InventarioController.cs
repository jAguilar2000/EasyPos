using EasyPos.Models;
using EasyPos.Models.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;

namespace EasyPos.Controllers
{
    public class InventarioController : Controller
    {
        private EasyPosEntities db = new EasyPosEntities();

        public ActionResult Index()
        {
            return View(db.Inventario.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "inventarioId,productoId,stockDisponible,stockMin,stockMax,estado")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                inventario.estado = true;
                db.Inventario.Add(inventario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventario);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario inventario = db.Inventario.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            return View(inventario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "inventarioId,productoId,stockDisponible,stockMin,stockMax,estado")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventario);
        }
    }
}
