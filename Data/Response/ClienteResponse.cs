using sistemadeventas.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace sistemadeventas.Data.Response
{
    public class ClienteResponse
    {
        [Key]
        public int ID { get; set; }
        public string? NombreC { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public int Cedula { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Venta> Ventas { get; set; }
    }
}
