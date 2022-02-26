using BackEndAlternativa.API.Data.Repositories.Interfaces;
using BackEndAlternativa.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAlternativa.API.Data.Repositories
{
    public class ProdutoRepo : IProdutoRepo
    {
        private readonly AlternativaContext _context;

        public ProdutoRepo(AlternativaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> GetById(int Id)
        {
            return await _context.produtos.AsNoTracking().Where(prod => prod.Id == Id)
                                                         .Include(prod => prod.Categoria)
                                                         .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Produto>> GetByName(string Name)
        {
            return await _context.produtos.AsNoTracking().Where(prod => prod.Nome.ToLower().Contains(Name.ToLower())).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetByCategoria(int CategoriaId)
        {
            return await _context.produtos.AsNoTracking().Where(prod => prod.CategoriaId == CategoriaId).ToListAsync();
        }

        public void Insert(Produto produto)
        {
            _context.Add(produto);
        }

        public void Update(Produto produto)
        {
            _context.Update(produto);
        }

        public void Delete(Produto produto)
        {
            _context.Remove(produto);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
