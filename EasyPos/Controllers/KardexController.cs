using EasyPos.Models;
using EasyPos.Models.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;

namespace EasyPos.Controllers
{
    public class KardexController : Controller
    {
        private EasyPosEntities db = new EasyPosEntities();

        public ActionResult Kardex()
        {
            return View(db.kardex.ToList());
        }

        //public ActionResult Kardex()
        //{
        //    return View();

        //}
    }
}
