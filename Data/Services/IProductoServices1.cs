using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using sistemadeventas.Data.Services;

public interface IProductoServices1
{
    Task<Result<List<ProductoResponse>>> Consultar(string filtro);
    Task<Result> Crear(ProductoRequest request);
    Task<Result> Eliminar(ProductoRequest request);
    Task<Result> Modificar(ProductoRequest request);
}