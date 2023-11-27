using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyPos.Models.ViewModels
{
    public class ProveedorVM
    {
        public int ProveedorId { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
    }
}