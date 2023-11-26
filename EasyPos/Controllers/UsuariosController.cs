using EasyPos.Models;
using EasyPos.Models.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EasyPos.Controllers
{
    public class UsuariosController : Controller
    {
        private EasyPosEntities db = new EasyPosEntities();

        public ActionResult Index()
        {
            return View(db.Usuario.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuarios = db.Usuario.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            var viewModel = new UsuarioVM
            {
                Usuario = usuarios
            };
            ViewBag.rolId = new SelectList(db.Rol.Where(x => x.estado), "rolId", "descripcion");
            ViewBag.userId = id;
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usuarioId,usuario1,nombre,password,email,estado")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.estado = true;
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usuarioId,usuario1,nombre,password,email,estado")] Usuario usuario)
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
        //[ValidateAntiForgeryToken]
        public ActionResult CreateRolUsuario([Bind(Include = "usuarioRolId,usuarioId,rolId,estado")] UsuarioRol usuarioRol)
        {
            //var permisoRol = Validate.ValidatePermission(nameof(UsuariosController), "editar");
            //if (!permisoRol.editar && !permisoRol.agregar)
            //{
            //    return RedirectToAction("Details", "Usuarios", new { id = usuarioRol.usuarioId });
            //}
            if (ModelState.IsValid)
            {
                var exists = db.UsuarioRol.AsNoTracking().Where(x => x.rolId == usuarioRol.rolId && x.usuarioId == usuarioRol.usuarioId).FirstOrDefault();
                if (exists != null)
                {
                    exists = db.UsuarioRol.AsNoTracking().Where(x => x.usuarioRolId == usuarioRol.usuarioRolId).FirstOrDefault();
                    if (exists != null)
                    {
                        db.Entry(usuarioRol).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                    return RedirectToAction("Details", "Usuarios", new { id = usuarioRol.usuarioId });
                }
                else
                {
                    if (usuarioRol.usuarioRolId == 0)
                    {
                        usuarioRol.estado = true;
                        db.UsuarioRol.Add(usuarioRol);
                    }
                    else
                    {
                        exists = db.UsuarioRol.AsNoTracking().Where(x => x.usuarioRolId == usuarioRol.usuarioRolId).FirstOrDefault();
                        if (exists != null)
                        {
                            db.Entry(usuarioRol).State = EntityState.Modified;
                        }
                    }
                }
                db.SaveChanges();
            }
            return RedirectToAction("Details", "Usuarios", new { id = usuarioRol.usuarioId });
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
