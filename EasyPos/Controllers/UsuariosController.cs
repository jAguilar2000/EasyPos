using EasyPos.Models;
using EasyPos.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly EasyPosDb db;

        public UsuariosController(EasyPosDb db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Usuario.ToListAsync());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Usuario usuarios = db.Usuario.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            var viewModel = new UsuarioVM
            {
                Usuario = usuarios,
                UsuarioRol = db.UsuarioRol.Include(x => x.Rol).Where(x => x.UsuarioId == id).ToList(),
            };
            ViewBag.RolId = new SelectList(db.Rol.Where(x => x.Estado), "RolId", "Descripcion");
            ViewBag.userId = id;
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Estado = true;
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult CreateRolUsuario(UsuarioRol usuarioRol)
        {
            if (ModelState.IsValid)
            {
                var exists = db.UsuarioRol.AsNoTracking().Where(x => x.RolId == usuarioRol.RolId && x.UsuarioId == usuarioRol.UsuarioId).FirstOrDefault();
                if (exists != null)
                {
                    exists = db.UsuarioRol.AsNoTracking().Where(x => x.UsuarioRolId == usuarioRol.UsuarioRolId).FirstOrDefault();
                    if (exists != null)
                    {
                        db.Entry(usuarioRol).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                    return RedirectToAction("Details", "Usuarios", new { id = usuarioRol.UsuarioId });
                }
                else
                {
                    if (usuarioRol.UsuarioRolId == 0)
                    {
                        usuarioRol.Estado = true;
                        db.UsuarioRol.Add(usuarioRol);
                    }
                    else
                    {
                        exists = db.UsuarioRol.AsNoTracking().Where(x => x.UsuarioRolId == usuarioRol.UsuarioRolId).FirstOrDefault();
                        if (exists != null)
                        {
                            db.Entry(usuarioRol).State = EntityState.Modified;
                        }
                    }
                }
                db.SaveChanges();
            }
            return RedirectToAction("Details", "Usuarios", new { id = usuarioRol.UsuarioId });
        }

    }
}
