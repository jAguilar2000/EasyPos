using System.ComponentModel.DataAnnotations;

namespace EasyPos.Models
{

    public partial class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public decimal Isv { get; set; }
        public bool Estado { get; set; }
    
        public virtual CategoriaProducto CategoriaProducto { get; set; } = new CategoriaProducto();
        public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; } = new HashSet<FacturaDetalle>();
        public virtual ICollection<Inventario> Inventario { get; set; } = new HashSet<Inventario>();
        public virtual ICollection<OrdenCompraDetalle> OrdenCompraDetalle { get; set; } = new HashSet<OrdenCompraDetalle>();
    }

}
