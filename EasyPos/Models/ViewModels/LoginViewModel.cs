using System.ComponentModel.DataAnnotations;

namespace EasyPos.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "*El usuario es un campo obligatorio")]
        public string usuario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*La contraseña es un campo requerido")]
        [DataType(DataType.Password)]
        public string passWord { get; set; }
    }
}
