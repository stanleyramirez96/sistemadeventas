using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using sistemadeventas.Data.Services;

public interface IVentaServices1
{
    Task<Result<List<VentaResponse>>> Consultar(string filtro);
    Task<Result> Crear(VentaRequest request);
    Task<Result> Eliminar(VentaRequest request);
    Task<Result> Modificar(VentaRequest request);
}