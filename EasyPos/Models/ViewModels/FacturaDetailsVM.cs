namespace EasyPos.Models.ViewModels
{

    public class FacturaDetailsVM
    {
        public int productoId { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal subTotal { get; set; }
        public decimal isv { get; set; }
    }

    public class FacturasPost
    {
        public List<FacturaDetailsVM> datosTabla { get; set; }
        public int clienteId { get; set; }
        public decimal subTotal { get; set; }
        public decimal isv { get; set; }
    }

    public class PrintFactura
    {
        public int facturaId { get; set; }
        public string numFactura { get; set;}
        public string clienteNombre { get; set; }
        public string fechaFactura { get; set; }
        public decimal totalIsv { get; set; }
        public decimal totalSubtotal { get; set; }
        public decimal totalPagar { get; set; }
        public List<PrintFacturaDetalle> detalles { get; set; }
    }

    public class PrintFacturaDetalle
    {
        public int codProducto { get; set; }
        public string producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal isv { get; set; }
        public decimal subTotal { get; set; }

    }
}
