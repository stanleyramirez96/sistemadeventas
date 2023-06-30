using sistemadeventas.Data.Context;
using sistemadeventas.Data.Models;
using sistemadeventas.Data.Request;
using sistemadeventas.Data.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace sistemadeventas.Data.Services
{
    public class ProductoServices : IProductoServices
    {
        private readonly ISistemaDeVentasDbContext dbContext;

        public class Result
        {
            public bool Success { get; set; }
            public string? Message { get; set; }
        }

        public class Result<T>
        {
            public bool Success { get; set; }
            public string? Message { get; set; }
            public T? Data { get; set; }
        }

        public ProductoServices(ISistemaDeVentasDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<Result<List<ProductoResponse>>> Consultar()
        {
            try
            {
                var productos = dbContext.Productos.ToList();
                var productosResponse = productos.Select(p => p.ToResponse()).ToList();

                return new Result<List<ProductoResponse>> { Success = true, Data = productosResponse };
            }
            catch (Exception ex)
            {
                return new Result<List<ProductoResponse>> { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result<ProductoResponse>> ConsultarPorId(int productoId)
        {
            try
            {
                var producto = dbContext.Productos.FirstOrDefault(p => p.ID == productoId);
                if (producto == null)
                {
                    return new Result<ProductoResponse> { Success = false, Message = "No se encontró el producto" };
                }

                var productoResponse = producto.ToResponse();
                return new Result<ProductoResponse> { Success = true, Data = productoResponse };
            }
            catch (Exception ex)
            {
                return new Result<ProductoResponse> { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result> Crear(ProductoRequest request)
        {
            try
            {
                var producto = Producto.Crear(request);
                dbContext.Productos.Add(producto);
                await dbContext.SaveChangesAsync();

                return new Result { Success = true, Message = "Producto creado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result> Modificar(int productoId, ProductoRequest request)
        {
            try
            {
                var producto = dbContext.Productos.FirstOrDefault(p => p.ID == productoId);
                if (producto == null)
                {
                    return new Result { Success = false, Message = "No se encontró el producto" };
                }

                producto.Modificar(request);
                await dbContext.SaveChangesAsync();

                return new Result { Success = true, Message = "Producto modificado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result> Eliminar(int productoId)
        {
            try
            {
                var producto = dbContext.Productos.FirstOrDefault(p => p.ID == productoId);
                if (producto == null)
                {
                    return new Result { Success = false, Message = "No se encontró el producto" };
                }

                dbContext.Productos.Remove(producto);
                await dbContext.SaveChangesAsync();

                return new Result { Success = true, Message = "Producto eliminado exitosamente" };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = ex.Message };
            }
        }
    }
}
