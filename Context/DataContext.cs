using ApiNexus.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiNexus.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Mapeia o Enum Status como string no banco
        modelBuilder.Entity<ProdutoModel>()
            .Property(p => p.status_)
            .HasConversion<string>();

        modelBuilder.Entity<ProdutoModel>()
            .Property(p => p.unidade_Medida)
            .HasConversion<string>();
    }

        public DbSet<UsuarioModel> caduse { get; set; }

        public DbSet<ClienteModel> cadcli { get; set; }

        public DbSet<ProdutoModel> cadpro { get; set; }
    }
}
