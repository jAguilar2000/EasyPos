//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EasyPos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inventario
    {
        public int inventarioId { get; set; }
        public int productoId { get; set; }
        public int stockDisponible { get; set; }
        public int stockMin { get; set; }
        public int stockMax { get; set; }
        public bool estado { get; set; }
    
        public virtual Producto Producto { get; set; }
    }
}