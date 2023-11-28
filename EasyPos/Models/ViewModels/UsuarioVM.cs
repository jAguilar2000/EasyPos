namespace EasyPos.Models.ViewModels
{
    public class UsuarioVM
    {
        public List<Usuario> UsuariosList { get; set; } = new List<Usuario>();
        public List<UsuarioRol> UsuarioRol { get; set; } = new List<UsuarioRol>();
        //public List<UsuarioRol> UsuarioRolList { get; set; } = new List<UsuarioRol>();
        public Usuario Usuario { get; set; } = new Usuario();
    }
}