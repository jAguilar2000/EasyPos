namespace EasyPos.Models.ViewModels
{
    public class UsuarioVM
    {
        public List<Usuario> UsuariosList { get; set; } = new List<Usuario>();
        public UsuarioRol UsuarioRol { get; set; } = new UsuarioRol();
        public Usuario Usuario { get; set; } = new Usuario();
    }
}