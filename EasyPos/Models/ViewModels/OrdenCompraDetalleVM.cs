using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyPos.Models.ViewModels
{
    public class OrdenCompraDetalleVM
    {
        public int OrdenCompraDetalleId { get; set; }
        public int CompraId { get; set; }
        //public int ProductoId { get; set; }
        public ProductoVM oProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Isv { get; set; }
        public int EstadoId { get; set; }
        public bool Estado { get; set; }    
    }
}