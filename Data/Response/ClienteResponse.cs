using sistemadeventas.Data.Models;
using sistemadeventas.Data.Request;

namespace sistemadeventas.Data.Response
{
    public class ClienteResponse
    {
        public int ID { get; set; }
        public string NombreC { get; set; } = null!;
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? Cedula { get; set; }
        public string? Direccion { get; set; }

        public ClienteRequest ToRequest()
        {
            return new ClienteRequest
            {
                ID = ID,
                NombreC = NombreC,
                Apellido = Apellido,
                Telefono = Telefono,
                Cedula = Cedula,
                Direccion = Direccion
            };
        }

    }
}
