using EasyPos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Controllers
{
    public class RolsController : Controller
    {
        private readonly EasyPosDb db;

        public RolsController(EasyPosDb db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            return View(db.Rol.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromBody] Rol rol)
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

        public ActionResult Edit(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromBody] Rol rol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rol);
        }

    }
}
