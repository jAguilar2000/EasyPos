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
    
    public partial class OrdenCompra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrdenCompra()
        {
            this.OrdenCompraDetalle = new HashSet<OrdenCompraDetalle>();
        }
    
        public int ordenCompraId { get; set; }
        public int proveedorId { get; set; }
        public System.DateTime fecha { get; set; }
        public decimal subTotal { get; set; }
        public decimal isv { get; set; }
        public decimal total { get; set; }
        public int usuarioId { get; set; }
        public bool estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenCompraDetalle> OrdenCompraDetalle { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
