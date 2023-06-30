using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;

namespace sistemadeventas.Data.Services
{
    public interface IProductoServices
    {
        Task<ProductoServices.Result<List<ProductoResponse>>> Consultar();
        Task<ProductoServices.Result<ProductoResponse>> ConsultarPorId(int productoId);
        Task<ProductoServices.Result> Crear(ProductoRequest request);
        Task<ProductoServices.Result> Eliminar(int productoId);
        Task<ProductoServices.Result> Modificar(int productoId, ProductoRequest request);
    }
}