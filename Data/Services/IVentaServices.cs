using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using sistemadeventas.Data.Services;

public interface IVentaServices
{
    Task<Result<List<VentaResponse>>> Consultar();
    Task<Result<List<ClienteResponse>>> ConsultarClientes();
    Task<Result<List<ProductoResponse>>> ConsultarProductos();
    Task<Result<VentaResponse>> Crear(VentaRequest request);
}