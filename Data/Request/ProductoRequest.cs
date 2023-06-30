using sistemadeventas.Data.Request;

namespace sistemadeventas.Data.Request
{
    public class ProductoRequest
    {
        public int ID { get; set; }
        public string? NombreP { get; set; }
        public decimal PrecioV { get; set; }
        public decimal PrecioC { get; set; }
        public int Cantidad { get; set; }

 
    }
}
