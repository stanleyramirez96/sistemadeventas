using System.ComponentModel.DataAnnotations;

namespace sistemadeventas.Data.Request
{
    public class ClienteRequest
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string NombreC { get; set; } = null!;

        [Required(ErrorMessage = "El Apellido es requerido")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "La cédula es requerida")]
        public string? Cedula { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        public string? Direccion { get; set; }
    }
}
