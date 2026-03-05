namespace PagosService.Models
{
    // Modelo de datos para representar un pago, con propiedades como Id, Total, Metodo y Fecha para almacenar la información relevante de cada pago realizado.
    public class Pago
    {
        
        public int Id { get; set; }
        public decimal Total { get; set; }
        public string Metodo { get; set; }
        public DateTime Fecha { get; set; }
    }
}