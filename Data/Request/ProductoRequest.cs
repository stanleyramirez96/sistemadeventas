namespace sistemadeventas.Data.Request;


public class ProductoRequest
{
    public int ID { get; set; }
    public string? NombreP { get; set; }
    public decimal Costo { get; set; }
    public decimal Total { get; set; }
    public int Cantidad { get; set; }


}
