using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using BackEndAlternativa.Domain.Models;
using BackEndAlternativa.Domain.Interfaces.Repositories;

namespace BackEndAlternativa.API.Data.Repositories
{
    public class CategoriaRepo : ICategoriaRepository
    {
        private readonly AlternativaContext _context;

        public CategoriaRepo(AlternativaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> Select()
        {
            return await _context.categorias.AsNoTracking().ToListAsync();
        }

        public async Task<Categoria> Select(int Id)
        {
            return await _context.categorias.AsNoTracking().Where(cat => cat.Id == Id).Include(cat => cat.Produtos).FirstOrDefaultAsync();
        }

        public Categoria Insert(Categoria categoria)
        {
            _context.Add(categoria);
            _context.SaveChanges();
            
            return categoria;
        }

        public Categoria Update(Categoria categoria)
        {
            //TODO: Insert e update assincronos.
            _context.Update(categoria);
            _context.SaveChanges();

            return categoria;
        }

        public Categoria Delete(Categoria categoria)
        {
            _context.Remove(categoria);
            _context.SaveChanges();

            return categoria;
        }
    }
}
