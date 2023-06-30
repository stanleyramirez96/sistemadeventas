using System.ComponentModel.DataAnnotations.Schema;

namespace sistemadeventas.Data.Response;
public class VentaResponse
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime Fecha { get; set; }
    public ClienteResponse Cliente { get; set; }
    public virtual ICollection<VentaDetalleResponse> Detalles { get; set; }

    [NotMapped]
    public decimal SubTotal =>
        Detalles != null ? //IF
        Detalles.Sum(d => d.SubTotal) //Verdadero
        :
        0;//Falso
}

