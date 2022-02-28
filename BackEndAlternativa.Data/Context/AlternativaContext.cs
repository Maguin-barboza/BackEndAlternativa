using BackEndAlternativa.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndAlternativa.API.Data
{
    public class AlternativaContext: DbContext
    {
        public AlternativaContext(DbContextOptions options): base(options) {    }

        public DbSet<Produto> produtos { get; set; }
        public DbSet<Categoria> categorias { get; set; }


    }
}
