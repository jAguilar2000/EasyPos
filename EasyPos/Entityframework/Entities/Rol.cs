using System.ComponentModel.DataAnnotations;

namespace EasyPos.Models
{

    public partial class Rol
    {
        [Key]
        public int RolId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Estado { get; set; }

        public virtual ICollection<UsuarioRol> UsuarioRol { get; set; } = new HashSet<UsuarioRol>();
    }

}
