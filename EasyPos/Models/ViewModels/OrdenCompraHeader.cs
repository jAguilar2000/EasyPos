namespace EasyPos.Models.ViewModels
{
    public class OrdenCompraHeader
    {
        public int CompraId { get; set; }
        public string nombreProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Isv { get; set; }
        public decimal Total { get; set; }
        public bool Estado { get; set; }
    }
}
