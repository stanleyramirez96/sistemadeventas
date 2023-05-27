using Microsoft.EntityFrameworkCore;
using sistemadeventas.Data.Context;
using sistemadeventas.Data.Models;
using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;

namespace sistemadeventas.Data.Services
{

    public class UsuarioServices : IUsuarioServices
    {
        public class Result
        {
            public bool Success { get; set; }
            public string Message { get; set; }
        }
        public class Result<T>
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public T? Data { get; set; }
        }
        private readonly IsistemadeventasDbcontext dbcontext;

        public UsuarioServices(IsistemadeventasDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;

        }
        public async Task<Result> Crear(UsuarioRequest request)
        {


            try
            {
                var usuario = Usuario.Crear(request);
                dbcontext.Usuarios.Add(usuario);
                await dbcontext.SaveChangesAsync();
                return new Result { Message = "Ok", Success = true };
            }
            catch (Exception ex)
            {
                return new Result { Message = ex.Message, Success = false };
            }
        }
        public async Task<Result> Modificar(UsuarioRequest request)
        {


            try
            {
                var usuario = await dbcontext.Usuarios.FirstOrDefaultAsync(c => c.ID == request.ID);
                if (usuario == null)
                    return new Result { Message = "No se encontro un usuario", Success = false };
                if (usuario.Modificar(request))
                    await dbcontext.SaveChangesAsync();
                return new Result { Message = "Ok", Success = true };
            }
            catch (Exception ex)
            {
                return new Result { Message = ex.Message, Success = false };
            }
        }

        public async Task<Result> Eliminar(UsuarioRequest request)
        {


            try
            {
                var usuario = await dbcontext.Usuarios.FirstOrDefaultAsync(c => c.ID == request.ID);
                if (usuario == null)
                    return new Result { Message = "No se encontro un usuario", Success = false };
                dbcontext.Usuarios.Remove(usuario);
                return new Result { Message = "Ok", Success = true };
            }
            catch (Exception ex)
            {
                return new Result { Message = ex.Message, Success = false };
            }
        }

        public async Task<Result<List<UsuarioResponse>>> Consultar(string filtro)
        {
            try
            {
                var usuario= await dbcontext.Usuarios.Where(c => (c.Nickname + "" + c.Contraseña)
                .ToLower().Contains(filtro.ToLower())
                ).Select(c => c.ToResponse()).ToListAsync();
                return new Result<List<UsuarioResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = usuario
                };
            }
            catch (Exception ex)
            {
                return new Result<List<UsuarioResponse>>
                {
                    Message = ex.Message,
                    Success = true,

                };
            }
        }
    }
}

