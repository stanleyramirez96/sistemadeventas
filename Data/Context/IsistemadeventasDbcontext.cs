using Microsoft.EntityFrameworkCore;
using sistemadeventas.Data.Models;

namespace sistemadeventas.Data.Context
{
    public interface IsistemadeventasDbcontext
    {
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Producto> Productos { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Venta> Ventas { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}