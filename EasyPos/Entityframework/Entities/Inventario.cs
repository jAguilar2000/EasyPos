using System.ComponentModel.DataAnnotations;

namespace EasyPos.Models
{

    public partial class Inventario
    {
        [Key]
        public int InventarioId { get; set; }
        public int ProductoId { get; set; }
        public int StockDisponible { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public bool Estado { get; set; }

        public virtual Producto Producto { get; set; } = new Producto();
    }
}
