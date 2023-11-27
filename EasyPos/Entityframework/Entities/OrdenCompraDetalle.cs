using System.ComponentModel.DataAnnotations;

namespace EasyPos.Models
{

    public partial class OrdenCompraDetalle
    {
        [Key]
        public int OrdenCompraDetalleId { get; set; }
        public int OrdenCompraId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Isv { get; set; }
        public int EstadoId { get; set; }
    
        public virtual Estado Estados { get; set; } = new Estado();
        public virtual OrdenCompra OrdenCompra { get; set; } = new OrdenCompra();
        public virtual Producto Producto { get; set; } = new Producto();
    }
}
