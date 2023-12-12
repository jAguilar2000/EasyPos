namespace EasyPos.Models.ViewModels
{
    public class OrdenCompraDetailsVM
    {
        public int productoId { get; set; }
        public int cantidad { get; set; }
        public decimal costo { get; set; }
        public decimal subTotal { get; set; }
        public decimal isv { get; set; }
    }

    public class OrdenCompraPost
    {
        public List<OrdenCompraDetailsVM> datosTabla { get; set; }
        public int proveedorId { get; set; }
        public decimal subTotal { get; set; }
        public decimal isv { get; set; }
    }

    public class PrintOrdenCompra
    {
        public int compraId { get; set; }
        public string proveedorNombre { get; set; }
        public string fecha { get; set; }
        public decimal totalIsv { get; set; }
        public decimal totalSubtotal { get; set; }
        public decimal totalPagar { get; set; }
        public List<PrintOrdenDetalle> detalles { get; set; }
    }

    public class PrintOrdenDetalle
    {
        public int codProducto { get; set; }
        public string producto { get; set; }
        public int cantidad { get; set; }
        public decimal costo { get; set; }
        public decimal isv { get; set; }
        public decimal subTotal { get; set; }

    }
}
