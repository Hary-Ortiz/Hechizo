namespace Presentacion.Models
{
    // Modelo de vista para representar la información de error, con una propiedad RequestId para almacenar el identificador de la solicitud y una propiedad ShowRequestId para determinar si se debe mostrar el identificador en la vista de error.
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
