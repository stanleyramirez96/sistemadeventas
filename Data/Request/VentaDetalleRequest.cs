using sistemadeventas.Data.Response;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemadeventas.Data.Request
{
    public class VentaDetalleRequest
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string? Descripcion { get; set; }

        public int Cantidad { get; set; }
        public decimal PrecioV { get; set; }
      
        public decimal SubTotal => Cantidad * PrecioV;
    }
}
