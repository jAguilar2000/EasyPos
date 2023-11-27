using System.ComponentModel.DataAnnotations;

namespace EasyPos.Models
{

    public partial class Estado
    {
        public Estado()
        {
            Factura = new HashSet<Factura>();
            OrdenCompraDetalle = new HashSet<OrdenCompraDetalle>();
        }

        [Key]
        public int EstadoId { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public virtual ICollection<Factura> Factura { get; set; }
        public virtual ICollection<OrdenCompraDetalle> OrdenCompraDetalle { get; set; }
    }
}
