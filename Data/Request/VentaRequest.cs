using sistemadeventas.Data.Request;

namespace sistemadeventas.Data.Request;


public class VentaRequest
{
    public int ID { get; set; }
    public int ClienteId { get; set; }
    public string NombreC { get; set; } = null!;
    public virtual ICollection<VentaDetalleRequest> Detalles { get; set; }  = new List < VentaDetalleRequest>();
    public decimal SubTotal => 
        Detalles != null?
        Detalles.Sum(d=>d.SubTotal)
        : 
        0;
    public DateTime Fecha { get; set; }

}
