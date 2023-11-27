
namespace EasyPos.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class OrdenCompra
    {
        [Key]
        public int OrdenCompraId { get; set; }
        public int ProveedorId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Isv { get; set; }
        public decimal Total { get; set; }
        public int UsuarioId { get; set; }
        public bool Estado { get; set; }
    
        public virtual ICollection<OrdenCompraDetalle> OrdenCompraDetalle { get; set; } = new HashSet<OrdenCompraDetalle>();
        public virtual Proveedor Proveedor { get; set; } = new Proveedor();
        public virtual Usuario Usuario { get; set; } = new Usuario();
    }
}
