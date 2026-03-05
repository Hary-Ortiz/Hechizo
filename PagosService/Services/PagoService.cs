using PagosService.Models;
// Servicio para manejar la lógica de negocio relacionada con los pagos, como procesar un pago o recuperar la lista de pagos realizados. El servicio utiliza una lista estática para almacenar los pagos, lo que permite simular un almacenamiento en memoria sin necesidad de una base de datos.

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