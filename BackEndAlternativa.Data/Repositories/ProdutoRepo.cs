using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using BackEndAlternativa.Domain.Models;
using BackEndAlternativa.Domain.Interfaces.Repositories;

namespace BackEndAlternativa.API.Data.Repositories
{
    public class ProdutoRepo : IProdutoRepository
    {
        private readonly AlternativaContext _context;

        public ProdutoRepo(AlternativaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> Select()
        {
            return await _context.produtos.AsNoTracking().Include(prod => prod.Categoria).ToListAsync();
        }

        public async Task<Produto> Select(int Id)
        {
            return await _context.produtos.AsNoTracking().Where(prod => prod.Id == Id)
                                                         .Include(prod => prod.Categoria)
                                                         .FirstOrDefaultAsync();
        }

        public Produto Insert(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();
            
            return produto;
        }

        public Produto Update(Produto produto)
        {
            _context.Update(produto);
            _context.SaveChanges();

            return produto;
        }

        public void Delete(Produto produto)
        {
            _context.Remove(produto);
            _context.SaveChanges();
        }
    }
}
