using System.ComponentModel.DataAnnotations;

namespace EasyPos.Models
{

    public partial class CategoriaProducto
    {
        public CategoriaProducto()
        {
            Productos = new HashSet<Producto>();
        }

        [Key]
        public int CategoriaId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Estado { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
