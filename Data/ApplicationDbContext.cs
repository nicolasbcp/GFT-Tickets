using System;
using System.Collections.Generic;
using System.Text;
using GFT_Tickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GFT_Tickets.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<CasaDeShow> CasasDeShow {get; set;}
        public DbSet<GeneroMusical> GenerosMusicais {get; set;}
        public DbSet<Evento> Eventos {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}
        public DbSet<Venda> Vendas {get; set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
