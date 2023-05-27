using Microsoft.Extensions.Hosting;
using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace sistemadeventas.Data.Models;
public class Usuario

{
    public Usuario()
    {
        Ventas = new List<Venta>();
    }
    [Key]
    public int ID { get; set; }
    public string? Nickname { get; set; }
    public string? Contraseña { get; set; }

    public virtual ICollection<Venta> Ventas { get; set; }
    public static Usuario Crear(UsuarioRequest usuario) => new Usuario()
    {
        Nickname = usuario.Nickname,
        Contraseña = usuario.Contraseña
    };

    public bool Modificar(UsuarioRequest usuario)
    {

        var  cambio = false;
        if (Nickname != usuario.Nickname)
        {

            Nickname = usuario.Nickname;
            cambio = true;

        }
        if (Contraseña != usuario.Contraseña)
        {

            Contraseña = usuario.Contraseña;
            cambio = true;
        }

        return cambio;
    }
    public UsuarioResponse ToResponse() => new UsuarioResponse() {
        Nickname = Nickname,
        Contraseña = Contraseña

    };
}