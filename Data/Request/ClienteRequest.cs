using sistemadeventas.Data.Models;

namespace sistemadeventas.Data.Request
    {
    public class ClienteRequest
    {
        public int ID { get; set; }
        public string NombreC { get; set; } = null!;
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? Cedula { get; set; }
        public string? Direccion { get; set; }

    }
}