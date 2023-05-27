using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.WebSockets;

namespace sistemadeventas.Data.Models;

public class Venta
{
    public Venta()
    {
        Detalles = new List<VentaDetalle>();
        Cliente = new Cliente();
        Usuario = new Usuario();
    }
    [Key]
    public int ID { get; set; }
    public int UsuarioId { get; set; }
    public int ClienteId { get; set; }
    public decimal Total { get; set; }
    public DateTime Fecha { get; set; }

    #region Relaciones

    public virtual ICollection<VentaDetalle> Detalles { get; set; }

    [ForeignKey(nameof(ClienteId))]
    public virtual Cliente Cliente { get; set; }

    [ForeignKey(nameof(UsuarioId))]
    public virtual Usuario Usuario { get; set; }
    #endregion
    #region Funciones
    public static Venta Crear(VentaRequest venta) => new Venta()
    {
        UsuarioId = venta.UsuarioId,
        ClienteId = venta.ClienteId,
        Fecha = venta.Fecha, 
        Total = venta.Total,
    };
    public bool Modificar(VentaRequest venta)
    { 
      
        var  cambio = false;
        if (UsuarioId != venta.UsuarioId) { 
        UsuarioId= venta.UsuarioId;
            cambio = true;
        }
        if (ClienteId != venta.ClienteId) { 
        
        ClienteId= venta.ClienteId;
            cambio = true;
        }
        return cambio;
    }
    #endregion
}
