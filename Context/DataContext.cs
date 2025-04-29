using ApiNexus.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiNexus.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> caduse { get; set; }

        public DbSet<ClienteModel> cadcli { get; set; }

    }
}
