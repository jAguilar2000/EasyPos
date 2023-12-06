using EasyPos.Models;
using EasyPos.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EasyPos.Controllers
{
    public class LoginController : Controller
    {
        private readonly EasyPosDb db;
        public LoginController(EasyPosDb _db)
        {
            this.db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    Usuario? user = db.Usuario.FirstOrDefault(x => x.NombreIdentificador == login.usuario);

                    if (user == null)
                    {
                        ModelState.AddModelError("", "Usuario no existe!");
                        return View(login);
                    }

                    var acceso = user.Password == login.passWord;
                    if (!acceso)
                    {
                        ModelState.AddModelError("", "Usuario o contraseña inválido!");
                        return View(login);
                    }
                    return RedirectToAction("Index", "Home");
                    //var menu = db.PermisosEnMenu(user.usuarioId).Select(x => new Menu
                    //{
                    //    SeguridadGrupoId = x.grupoId,
                    //    Grupo = x.menu,
                    //    Opcion = x.submenu,
                    //    PermisoId = x.permisoId,
                    //    Controller = x.controlador,
                    //    Icono = x.iconoMenu,
                    //    Orden = x.ordenMenu,
                    //    Ordensubmenu = x.ordenSubmenu,
                    //}).ToList();

                    //Session["Menu"] = menu.OrderBy(c => c.Orden).ToList();
                    //Session["UserId"] = user.usuarioId;
                    //Session["User"] = user.usuario;
                    //Session["UserName"] = user.nombre;

                    //bool accDashboard = menu.Any(x => x.Controller.Contains("Dashboard"));
                    //if (accDashboard)
                    //{
                    //    var permisoRol = Validate.ValidatePermission(nameof(DashboardController), "consultar");
                    //    var rol = db.UsuarioRol.Where(x => x.rolId == permisoRol.RolId).Include(x => x.Roles).FirstOrDefault();
                    //    if (rol.Roles.descripcion.Contains("Admin") || rol.Roles.descripcion.Contains("RRHH"))
                    //    {
                    //        return RedirectToAction("Index", "Dashboard");
                    //    }
                    //}
                    //return RedirectToAction("Index", "Home");

                    //ModelState.AddModelError("", authenticationResult.ErrorMessage);
                }
                return View(login);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al enlistar los usuarios: " + ex.Message.ToString());
                return View();
            }
        }
    }
}
