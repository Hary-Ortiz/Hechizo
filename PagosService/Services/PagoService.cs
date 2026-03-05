using PagosService.Models;

namespace PagosService.Services
{
    public class PagoService
    {
        private static List<Pago> pagos = new();

        public List<Pago> ObtenerPagos()
        {
            return pagos;
        }

        public void ProcesarPago(Pago pago)
        {
            pago.Id = pagos.Count + 1;
            pago.Fecha = DateTime.Now;

            pagos.Add(pago);
        }
    }
}