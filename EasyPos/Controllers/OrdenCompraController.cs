using EasyPos.Models;
using EasyPos.Models.ViewModels;
using EasyPos.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EasyPos.Controllers
{
    public class OrdenCompraController : Controller
    {
        private readonly EasyPosDb db;
        private readonly SessionHelper _sessionHelper;

        public OrdenCompraController(EasyPosDb db, SessionHelper sessionHelper)
        {
            this.db = db;
            _sessionHelper = sessionHelper ?? throw new ArgumentNullException(nameof(sessionHelper));

        }
        public async Task<IActionResult> Index()
        {

            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Compras");
            if (acceso)
            {
                var listCompra = await db.OrdenCompra.Select(x => new OrdenCompraHeader
                {
                    CompraId = x.OrdenCompraId,
                    Fecha = x.Fecha,
                    nombreProveedor = x.Proveedor.Nombre,
                    SubTotal = x.SubTotal,
                    Isv = x.Isv,
                    Total = x.Total,
                    Estado = x.Estado

                }).ToListAsync();
               
                return View(listCompra);
            }
            else
            {
                return RedirectToPage("/Privacy");
            }             
        }

        public async Task<IActionResult> Create()
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Compras");
            if (acceso)
            {
                ViewBag.proveedorId = new SelectList(db.Proveedor.Where(x => x.Estado == true), "ProveedorId", "Nombre");
                ViewBag.productoId = new SelectList(db.Producto.Where(x => x.Estado == true), "ProductoId", "Descripcion");
                return View();
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }

        [HttpPost]
        public JsonResult CreateDetalle([FromBody] OrdenCompraPost datos)
        {

            OrdenCompra newOrden = new OrdenCompra
            {
                ProveedorId = datos.proveedorId,
                Fecha = DateTime.Now,
                SubTotal = datos.subTotal,
                Isv = datos.isv,
                Total = datos.subTotal + datos.isv,
                Estado = true,
                UsuarioId = 8
            };
            db.OrdenCompra.Add(newOrden);
            db.SaveChanges();

            foreach (var dato in datos.datosTabla)
            {

                var newDetalle = new OrdenCompraDetalle();
                newDetalle.OrdenCompraId = newOrden.OrdenCompraId;
                newDetalle.ProductoId = dato.productoId;
                newDetalle.Cantidad = dato.cantidad;
                newDetalle.Costo = dato.costo;
                newDetalle.Isv = dato.isv;
                newDetalle.EstadoId = 1;
                db.OrdenCompraDetalle.Add(newDetalle);
            }
            db.SaveChanges();

            return Json(newOrden.OrdenCompraId);
        }


        public IActionResult PreviewOrden(int compraId)
        {
            List<string> listaRecuperada = _sessionHelper.GetListMenu<List<string>>("ListMenu");

            bool acceso = listaRecuperada.Any(x => x.ToString() == "Compras");
            if (acceso)
            {
                var orden = db.OrdenCompra.Find(compraId);

                if (orden == null)
                {
                    return NotFound();
                }

                PrintOrdenCompra printOrden = new PrintOrdenCompra
                {
                    compraId = orden.OrdenCompraId,
                    proveedorNombre = db.Proveedor.FirstOrDefault(x => x.ProveedorId == orden.ProveedorId).Nombre,
                    fecha = orden.Fecha.ToString("dd/MM/yyyy"),
                    detalles = db.OrdenCompraDetalle.Include(x => x.OrdenCompra).Where(x => x.OrdenCompraId == orden.OrdenCompraId).Select(x => new PrintOrdenDetalle
                    {
                        codProducto = x.ProductoId,
                        producto = x.Producto.Descripcion,
                        cantidad = x.Cantidad,
                        costo = x.Costo,
                        isv = x.Isv,
                    }).ToList(),
                    totalSubtotal = orden.SubTotal,
                    totalIsv = orden.Isv,
                    totalPagar = orden.Total,
                };
                return View(printOrden); // Puedes pasar el modelo de factura a la vista
            }
            else
            {
                return RedirectToPage("/Privacy");
            }
        }
    }
}
