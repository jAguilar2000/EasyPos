using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyPos.Models.ViewModels
{
    public class OrdenCompraVM
    {
        public int OrdenCompraId { get; set; }
        //public int ProveedorId { get; set; }
        public ProveedorVM oProveedor { get; set; }

        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Isv { get; set; }
        public decimal Total { get; set; }
        public int UsuarioId { get; set; }
        public bool Estado { get; set; }

        public List<OrdenCompraDetalleVM> oListaDetalleCompra { get; set; }
    }
}