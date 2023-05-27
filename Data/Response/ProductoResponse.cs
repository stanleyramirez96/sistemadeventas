using sistemadeventas.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace sistemadeventas.Data.Response
{

    public class ProductoResponse
    {
        [Key]
        public int ID { get; set; }
        public string? NombreP { get; set; }
        public decimal Costo { get; set; }
        public decimal Total { get; set; }
        public int Cantidad { get; set; }

        public virtual ICollection<Venta> Ventas { get; set; }

    }
}
