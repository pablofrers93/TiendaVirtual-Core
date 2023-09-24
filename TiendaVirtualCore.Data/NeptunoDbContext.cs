using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data
{
    public class NeptunoDbContext : DbContext
    {
        public NeptunoDbContext(DbContextOptions<NeptunoDbContext> options):base(options)
        {
            
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Categoria> Categorias { get; set; }
    }
}
