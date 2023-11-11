using BTZ_Transports.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace BTZ_Transports.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Combustivel> Combustiveis { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Combustivel>().HasData(new Combustivel
            {
                Id = 1,
                Nome = "Gasolina",
                Preco = decimal.Parse("4,29")
            });
            modelBuilder.Entity<Combustivel>().HasData(new Combustivel
            {
                Id = 2,
                Nome = "Etanol",
                Preco = decimal.Parse("2,99")
            });
            modelBuilder.Entity<Combustivel>().HasData(new Combustivel
            {
                Id = 3,
                Nome = "Diesel",
                Preco = decimal.Parse("2,09")
            });

        }
    }
}
