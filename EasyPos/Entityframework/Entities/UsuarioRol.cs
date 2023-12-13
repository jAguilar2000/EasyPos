using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyPos.Models
{

    public partial class UsuarioRol
    {
        [Key]
        public int UsuarioRolId { get; set; }
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
        public bool Estado { get; set; }

        //[ForeignKey("RolId")]
        public virtual Rol? Rol { get; set; } //= new Rol();
        //[ForeignKey("UsuarioId")]
        public virtual Usuario? Usuario { get; set; } //= new Usuario();
    }
}
