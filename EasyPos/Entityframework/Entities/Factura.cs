using System.ComponentModel.DataAnnotations;

namespace EasyPos.Models
{

    public partial class Factura
    {
        public Factura()
        {
            FacturaDetalle = new HashSet<FacturaDetalle>();
        }

        [Key]
        public int FacturaId { get; set; }
        public string NumFactura { get; set; } = string.Empty;
        public int ClienteId { get; set; }
        public DateTime FechaCrea { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Isv { get; set; }
        public decimal Total { get; set; }
        public string Observacion { get; set; } = string.Empty;
        public int EstadoId { get; set; }
        public int UsuarioCreaId { get; set; }
        public int? UsuarioModificaId { get; set; }
        public bool Activo { get; set; }

        public virtual Cliente? Cliente { get; set; } 
        public virtual Estado? Estados { get; set; } 
        public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; }
        public virtual Usuario? UsuarioCrea { get; set; }
        public virtual Usuario? UsuarioModifica { get; set; }
    }
}
