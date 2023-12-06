using EasyPos.Models;
using EasyPos.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Controllers
{
    public class FacturaController : Controller
    {
        private readonly EasyPosDb db;

        public FacturaController(EasyPosDb db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            var listFactura = await db.Factura.Select(x => new FacturaHeader
            {
                FacturaId = x.FacturaId,
                NumFactura = x.NumFactura,
                FechaCrea = x.FechaCrea,
                nombreCliente = x.Cliente.Nombre,
                SubTotal = x.Total,
                Isv = x.Isv,
                Total = x.Total,
                Activo = x.Activo
            }).ToListAsync();
            return View(listFactura);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            //Factura factura = db.Factura.Find(id);
            //if (factura == null)
            //{
            //    return NotFound();
            //}

            //var viewModel = new FacturaVM
            //{
            //    Factura = factura,
            //    FacturaDetalle = db.FacturaDetalle.Where(x => x.FacturaId == id).ToList(),
            //};

            return View();
            //return View(viewModel);
        }
    }
}
