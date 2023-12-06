namespace EasyPos.Models.ViewModels
{
    public class FacturaVM
    {
        public Factura Factura { get; set; } = new Factura();
        public List<FacturaDetalle> FacturaDetalle { get; set; } = new List<FacturaDetalle>();
    }
}
