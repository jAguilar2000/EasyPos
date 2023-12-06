namespace EasyPos.Models.ViewModels
{
    public class FacturaHeader
    {
        public int FacturaId { get; set; }
        public string NumFactura { get; set; }
        public DateTime FechaCrea { get; set; }
        public string nombreCliente { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Isv { get; set; }
        public decimal Total { get; set; }
        public bool Activo { get; set; }
    }
}
