using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;

namespace sistemadeventas.Data.Services
{
    public interface IUsuarioServices
    {
        Task<UsuarioServices.Result<List<UsuarioResponse>>> Consultar(string filtro);
        Task<UsuarioServices.Result> Crear(UsuarioRequest request);
        Task<UsuarioServices.Result> Eliminar(UsuarioRequest request);
        Task<UsuarioServices.Result> Modificar(UsuarioRequest request);
    }
}