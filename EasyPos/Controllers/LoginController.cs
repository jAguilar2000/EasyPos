using EasyPos.Models;
using EasyPos.Models.ViewModels;
using EasyPos.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EasyPos.Controllers
{
    public class LoginController : Controller
    {
        private readonly EasyPosDb db;
        private readonly SessionHelper _sessionHelper;
        public LoginController(EasyPosDb _db, SessionHelper sessionHelper)
        {
            this.db = _db;
            _sessionHelper = sessionHelper ?? throw new ArgumentNullException(nameof(sessionHelper));
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
                    var menu = db.UsuarioRol.Include(x => x.Rol).Where(x => x.UsuarioId == user.UsuarioId && x.Estado == true).ToList();


                    HttpContext.Session.SetString("UserId", user.UsuarioId.ToString());
                    HttpContext.Session.SetString("User", user.NombreIdentificador.ToString());
                    HttpContext.Session.SetString("UserName", user.Nombre.ToString());

                    List<string> lista = new List<string>();
                    foreach (var item in menu)
                    {
                        lista.Add(item.Rol.Descripcion.ToString());
                    }
                    _sessionHelper.SetListMenu("ListMenu", lista);

                    //var userId = HttpContext.Session.GetString("UserId");
                    //var User = HttpContext.Session.GetString("User");
                    //var UserName = HttpContext.Session.GetString("UserName");

                    return RedirectToAction("Index", "Home");
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
