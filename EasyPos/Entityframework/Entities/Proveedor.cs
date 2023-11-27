namespace EasyPos.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Proveedor
    {    
        [Key]
        public int ProveedorId { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public bool Estado { get; set; }

        public virtual ICollection<OrdenCompra> OrdenCompra { get; set; } = new HashSet<OrdenCompra>();
    }
}
