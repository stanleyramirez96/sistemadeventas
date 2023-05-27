using Microsoft.EntityFrameworkCore;
using sistemadeventas.Data.Models;
namespace sistemadeventas.Data.Context
{
    public class sistemadeventasDbcontext : DbContext, IsistemadeventasDbcontext
    {
        private readonly IConfiguration cofing;
        public sistemadeventasDbcontext(IConfiguration confing)
        {
            this.cofing = confing;

        }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: cofing.GetConnectionString(name: "MSSQL"));
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}