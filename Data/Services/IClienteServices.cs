using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;

public interface IClienteServices
{
    Task<ClienteServices.Result<List<ClienteResponse>>> Consultar(string filtro);
    Task<ClienteServices.Result> Crear(ClienteRequest request);
    Task<ClienteServices.Result> Eliminar(ClienteRequest request);
    Task<ClienteServices.Result> Modificar(ClienteRequest request);
}