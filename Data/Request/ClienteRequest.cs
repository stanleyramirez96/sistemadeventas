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

        [Required(ErrorMessage = "El tel�fono es requerido")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "La c�dula es requerida")]
        public string? Cedula { get; set; }

        [Required(ErrorMessage = "La direcci�n es requerida")]
        public string? Direccion { get; set; }
    }
}
