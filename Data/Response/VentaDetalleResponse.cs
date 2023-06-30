
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemadeventas.Data.Response
{
    public class VentaDetalleResponse
    {

        public int Id { get; set; }
        public ProductoResponse Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioV { get; set; }
        public int VentaId { get; set; }


        [NotMapped]
        public decimal SubTotal => Cantidad * PrecioV;

    }
}
