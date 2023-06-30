using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace sistemadeventas.Data.Models;

public class Venta
{

    public Venta()
    {
        
        Detalles = new List<VentaDetalle>();
    }

    [Key]
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime Fecha { get; set; }
    public virtual ICollection<VentaDetalle> Detalles { get; set; }
    public static Venta Crear(VentaRequest request)
        => new ()
        {
            ClienteId = request.ClienteId,
            Fecha = DateTime.Now,
            Detalles = request.Detalles
            .Select(detalle => VentaDetalle.Crear(detalle))
            .ToList()
        };

    #region Relaciones
    [ForeignKey(nameof(ClienteId))]
    public virtual Cliente Cliente { get; set; }

    #endregion

    [NotMapped]
    public decimal SubTotal =>
        Detalles != null ? //IF
        Detalles.Sum(d => d.SubTotal)
        :
        0;

    public VentaResponse ToResponse()
        => new()
        {
            Id = Id,
            ClienteId = ClienteId,
            Fecha = Fecha,
            Cliente = Cliente.ToResponse(),
            Detalles = Detalles.Select(d => d.ToResponse()).ToList()
        };

}
