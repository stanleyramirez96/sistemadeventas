using sistemadeventas.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace sistemadeventas.Data.Request{
public class UsuarioRequest

{
    [Key]
    public int ID { get; set; }
    public string? Nickname { get; set; }
    public string? Contraseña { get; set; }

    public virtual ICollection<Venta> Ventas { get; set; }

}

}

