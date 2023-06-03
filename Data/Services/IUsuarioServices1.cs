using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;

namespace sistemadeventas.Data.Services
{
    public interface IUsuarioServices1
    {
        Task<Result<List<UsuarioResponse>>> Consultar(string filtro);
        Task<Result> Crear(UsuarioRequest request);
        Task<Result> Eliminar(UsuarioRequest request);
        Task<Result> Modificar(UsuarioRequest request);
    }
}