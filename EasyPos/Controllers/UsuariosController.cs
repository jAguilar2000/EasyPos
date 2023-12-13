using EasyPos.Models;
using EasyPos.Models.ViewModels;
using EasyPos.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly EasyPosDb db;
        private readonly SessionHelper _sessionHelper;
        public UsuariosController(EasyPosDb db, SessionHelper sessionHelper)
        {
            this.db = db;
            _sessionHelper = sessionHelper ?? throw new ArgumentNullException(nameof(sessionHelper));
        }

        public async Task<IActionResult> Index()
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Usuarios");
            if (acceso)
            {
                return View(await db.Usuario.ToListAsync());
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

        public ActionResult Details(int? id)
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Usuarios");
            if (acceso)
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
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

        public ActionResult Create()
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Usuarios");
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
        public ActionResult Create(Usuario usuario)
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Usuarios");
            if (acceso)
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
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

        public ActionResult Edit(int? id)
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Usuarios");
            if (acceso)
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
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Usuarios");
            if (acceso)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

        [HttpPost]
        public ActionResult CreateRolUsuario(UsuarioRol usuarioRol)
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Usuarios");
            if (acceso)
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
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

    }
}
