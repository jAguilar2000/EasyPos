using System.ComponentModel.DataAnnotations;

namespace EasyPos.Models
{

    public partial class UsuarioRol
    {
        [Key]
        public int UsuarioRolId { get; set; }
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
        public bool Estado { get; set; }

        public virtual Rol Rol { get; set; } = new Rol();
        public virtual Usuario Usuario { get; set; } = new Usuario();
    }
}
