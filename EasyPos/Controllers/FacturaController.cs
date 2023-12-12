using EasyPos.Models;
using EasyPos.Models.ViewModels;
using EasyPos.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Controllers
{
    public class FacturaController : Controller
    {
        private readonly EasyPosDb db;
        private readonly SessionHelper _sessionHelper;
        public FacturaController(EasyPosDb db, SessionHelper sessionHelper)
        {
            this.db = db;
            _sessionHelper = sessionHelper ?? throw new ArgumentNullException(nameof(sessionHelper));
        }
        public async Task<IActionResult> Index()
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Factura");
            if (acceso)
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
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

        public async Task<IActionResult> Details()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Factura");
            if (acceso)
            {
                ViewBag.clienteId = new SelectList(db.Cliente.Where(x => x.Estado == true), "ClienteId", "Nombre");
                ViewBag.productoId = new SelectList(db.Producto.Where(x => x.Estado == true), "ProductoId", "Descripcion");
                return View();
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

        [HttpPost]
        public JsonResult CreateDetalle([FromBody] FacturasPost datos)
        {

            string correlativoAct = CorrelativoActual();
            int numeroCorrelativo = int.Parse(correlativoAct);
            int newNumero = numeroCorrelativo + 1;

            string newCorrelativo = newNumero.ToString().PadLeft(10, '0');

            Factura newFactura = new Factura
            {
                NumFactura = newCorrelativo,
                ClienteId = datos.clienteId,
                FechaCrea = DateTime.Now,
                SubTotal = datos.subTotal,
                Isv = datos.isv,
                Total = datos.subTotal + datos.isv,
                Observacion = ".",
                EstadoId = 1,
                UsuarioCreaId = 8,
                Activo = true,
            };
            db.Factura.Add(newFactura);
            db.SaveChanges();

            foreach (var dato in datos.datosTabla)
            {

                var newDetalle = new FacturaDetalle();
                newDetalle.FacturaId = newFactura.FacturaId;
                newDetalle.ProductoId = dato.productoId;
                newDetalle.Cantidad = dato.cantidad;
                newDetalle.Precio = dato.precio;
                newDetalle.SubTotal = dato.subTotal;
                newDetalle.Isv = dato.isv;
                newDetalle.Estado = true;
                db.FacturaDetalle.Add(newDetalle);
            }
            db.SaveChanges();

            return Json(newFactura.FacturaId);

        }

        public string CorrelativoActual()
        {
            var ultimaFactura = db.Factura.OrderBy(x => x.FacturaId).LastOrDefault();
            string correlativoActual = ultimaFactura?.NumFactura ?? "0000000000";
            return correlativoActual;
        }

        public JsonResult GetProducto(int productoId)
        {
            var producto = db.Producto.FirstOrDefault(x => x.ProductoId == productoId);
            return Json(producto);
        }

        public IActionResult PreviewFactura(int facturaId)
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Factura");
            if (acceso)
            {
                var factura = db.Factura.Find(facturaId);

                if (factura == null)
                {
                    return NotFound();
                }

                PrintFactura printFactura = new PrintFactura
                {
                    facturaId = factura.FacturaId,
                    numFactura = factura.NumFactura,
                    clienteNombre = db.Cliente.FirstOrDefault(x => x.ClienteId == factura.ClienteId).Nombre,
                    fechaFactura = factura.FechaCrea.ToString("dd/MM/yyyy"),
                    detalles = db.FacturaDetalle.Include(x => x.Factura).Where(x => x.FacturaId == factura.FacturaId && x.Estado == true).Select(x => new PrintFacturaDetalle
                    {
                        codProducto = x.ProductoId,
                        producto = x.Producto.Descripcion,
                        cantidad = x.Cantidad,
                        precio = x.Precio,
                        isv = x.Isv,
                        subTotal = x.SubTotal + x.Isv,
                    }).ToList(),
                    totalSubtotal = factura.SubTotal,
                    totalIsv = factura.Isv,
                    totalPagar = factura.Total,
                };
                return View(printFactura); // Puedes pasar el modelo de factura a la vista
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }
    }
}
