using System.Collections.Generic;

namespace EasyPos.Models.ViewModels
{
    public class UsuarioVM
    {
        public List<Usuario> UsuariosList { get; set; }
        public UsuarioRol UsuarioRol { get; set; }
        public Usuario Usuario { get; set; }
    }
}