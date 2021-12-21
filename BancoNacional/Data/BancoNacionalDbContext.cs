using BancoNacional.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoNacional.Data
{
    public class BancoNacionalDbContext : DbContext
    {
        public BancoNacionalDbContext() : base(){}

        public BancoNacionalDbContext(DbContextOptions options): base(options) { }

        public DbSet<Agencias> Agencias { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Gerentes> Gerentes { get; set; }
        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<ContaPoupanca> ContaPoupanca { get; set; }

    }
}
