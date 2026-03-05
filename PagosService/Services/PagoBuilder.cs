using PagosService.Models;

// Builder para crear objetos Pago de forma fluida

namespace PagosService.Services
{
    public class PagoBuilder
    {
        private Pago _pago = new Pago();

        public PagoBuilder ConTotal(decimal total)
        {
            _pago.Total = total;
            return this;
        }

        public PagoBuilder ConMetodo(string metodo)
        {
            _pago.Metodo = metodo;
            return this;
        }

        public Pago Build()
        {
            _pago.Fecha = DateTime.Now;
            return _pago;
        }
    }
}