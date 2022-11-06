using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Anuncios.mvc.Models;

namespace Anuncios.mvc.Data
{
    public class AnunciosmvcContext : DbContext
    {
        public AnunciosmvcContext (DbContextOptions<AnunciosmvcContext> options)
            : base(options)
        {
        }

        public DbSet<Anuncios.mvc.Models.UsuarioModel> Usuarios { get; set; } = default!;

        public DbSet<Anuncios.mvc.Models.VagaModel> Vagas { get; set; }
    }
}
