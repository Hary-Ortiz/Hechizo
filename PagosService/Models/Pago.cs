namespace PagosService.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public string Metodo { get; set; }
        public DateTime Fecha { get; set; }
    }
}