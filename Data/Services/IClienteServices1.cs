using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using sistemadeventas.Data.Services;

public interface IClienteServices1
{
    Task<Result<List<ClienteResponse>>> Consultar(string filtro);
    Task<Result> Crear(ClienteRequest request);
    Task<Result> Eliminar(ClienteRequest request);
    Task<Result> Modificar(ClienteRequest request);
}