using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AspNetCore.IQueryable.Extensions.Filter;

using BackEndAlternativa.API.Data.Repositories.Filters;
using BackEndAlternativa.API.Data.Repositories.Interfaces;
using BackEndAlternativa.Domain.Models;



namespace BackEndAlternativa.API.Data.Repositories
{
    public class CategoriaRepo : ICategoriaRepo
    {
        private readonly AlternativaContext _context;

        public CategoriaRepo(AlternativaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAll(FilterCategoria query)
        {
            return await _context.categorias.AsNoTracking().Filter(query).ToListAsync();
        }

        public async Task<Categoria> GetById(int Id)
        {
            return await _context.categorias.AsNoTracking().Where(cat => cat.Id == Id).Include(cat => cat.Produtos).FirstOrDefaultAsync();
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
