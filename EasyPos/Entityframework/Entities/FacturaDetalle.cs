using System.ComponentModel.DataAnnotations;

namespace EasyPos.Models
{

    public partial class FacturaDetalle
    {
        [Key]
        public int FacturaDetalleId { get; set; }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Isv { get; set; }
        public bool Estado { get; set; }
    
        public virtual Factura Factura { get; set; } = new Factura();
        public virtual Producto Producto { get; set; } = new Producto();
    }
}
