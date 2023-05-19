namespace sistemadeventas.Data.Models;
public class Usuario

{
    public int ID { get; set; }
    public string? Nickname { get; set; }
    public string? Contraseña { get; set; }

    public virtual ICollection<Venta> Ventas { get; set; }

}