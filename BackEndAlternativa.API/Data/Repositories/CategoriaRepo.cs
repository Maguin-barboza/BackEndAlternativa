using BackEndAlternativa.API.Data.Repositories.Interfaces;
using BackEndAlternativa.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAlternativa.API.Data.Repositories
{
    public class CategoriaRepo : ICategoriaRepo
    {
        private readonly AlternativaContext _context;

        public CategoriaRepo(AlternativaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.categorias.AsNoTracking().ToListAsync();
        }

        public async Task<Categoria> GetById(int Id)
        {
            return await _context.categorias.AsNoTracking().Where(cat => cat.Id == Id).Include(cat => cat.produtos).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Categoria>> GetByName(string Nome)
        {
            return await _context.categorias.AsNoTracking().Where(cat => cat.Nome.ToLower().Contains(Nome.ToLower())).ToListAsync();
        }

        public async Task<bool> HasProd(int Id)
        {
            Categoria categoriaAux = await _context.categorias.AsNoTracking()
                                                   .Where(cat => cat.Id == Id)
                                                   .Include(cat => cat.produtos).FirstOrDefaultAsync();
            
            return categoriaAux.produtos.Count() > 0;
        }

        public void Insert(Categoria categoria)
        {
            _context.Add(categoria);
        }

        public void Update(Categoria categoria)
        {
            _context.Update(categoria);
        }

        public void Delete(Categoria categoria)
        {
            _context.Remove(categoria);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
