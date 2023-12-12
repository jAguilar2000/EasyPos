using System.ComponentModel.DataAnnotations;

namespace EasyPos.Models
{
    public partial class kardex
    {
        [Key]
        public DateTime Fecha { get; set; } 
        public string Categoria { get; set; }
        public string descripcion { get; set; }
        public int Compra { get; set; }
        public int Venta { get; set; }
        public int Acumulado { get; set; }
    }
}
