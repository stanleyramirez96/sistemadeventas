namespace sistemadeventas.Data.Request;


public class VentaRequest
{
    public int ID { get; set; }
    public int UsuarioId { get; set; }
    public int ClienteId { get; set; }
    public decimal Total { get; set; }
    public DateTime Fecha { get; set; }

}
