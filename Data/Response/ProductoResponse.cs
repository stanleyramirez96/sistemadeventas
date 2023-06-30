using sistemadeventas.Data.Request;

namespace sistemadeventas.Data.Response
{
    public class ProductoResponse
    {
        public int ID { get; set; }
        public string? NombreP { get; set; }
        public string? Descripcion { get; set; }
        public decimal PrecioV { get; set; }
        public decimal PrecioC { get; set; }
        public int Cantidad { get; set; }

        public ProductoRequest ToRequest()
        {
            return new ProductoRequest
            {
                ID = ID,
                NombreP = NombreP,
                PrecioV = PrecioV,
                PrecioC = PrecioC,
                Cantidad = Cantidad
            };
        }
    }
}
