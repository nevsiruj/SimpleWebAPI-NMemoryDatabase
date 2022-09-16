using Microsoft.EntityFrameworkCore;

namespace WEB_API.Entities
{
    public partial class ClienteDBContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public ClienteDBContext()
        {

        }
        public ClienteDBContext(DbContextOptions<ClienteDBContext> options)
            : base(options)
        {

        }      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            modelBuilder.Entity<Cliente>().Property(e => e.Id).ValueGeneratedNever();


        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(new Cliente(Guid.NewGuid(), "Melden", "Ortega", "Puerreydon 277"));
        }
    }
}
