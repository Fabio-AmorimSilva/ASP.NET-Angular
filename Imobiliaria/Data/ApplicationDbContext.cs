using Imobiliaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imobiliaria.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(): base()
        {

        }

        public ApplicationDbContext(DbContextOptions options)
            : base(options) 
        { 
        
        }

        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Corretor> Corretores { get; set; }
        public DbSet<Dono> Donos { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }


    }
}
