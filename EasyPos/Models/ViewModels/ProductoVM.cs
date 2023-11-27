using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyPos.Models.ViewModels
{
    public class ProductoVM
    {
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public decimal Isv { get; set; }
        public bool Estado { get; set; }
    }
}