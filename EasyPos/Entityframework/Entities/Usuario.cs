using System.ComponentModel.DataAnnotations;

namespace EasyPos.Models
{

    public partial class Usuario
    {
        public Usuario()
        {
            OrdenCompra = new HashSet<OrdenCompra>();
            UsuarioRol = new HashSet<UsuarioRol>();
        }
    
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string NombreIdentificador { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Estado { get; set; }
    
        public virtual ICollection<OrdenCompra> OrdenCompra { get; set; }
        public virtual ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}
