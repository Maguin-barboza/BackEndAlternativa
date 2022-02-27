﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AspNetCore.IQueryable.Extensions.Filter;
using Microsoft.EntityFrameworkCore;

using BackEndAlternativa.API.Data.Repositories.Filters;
using BackEndAlternativa.API.Data.Repositories.Interfaces;
using BackEndAlternativa.Domain.Models;

namespace BackEndAlternativa.API.Data.Repositories
{
    public class ProdutoRepo : IProdutoRepo
    {
        private readonly AlternativaContext _context;

        public ProdutoRepo(AlternativaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll(FilterProduto query)
        {
            return await _context.produtos.Filter(query).AsNoTracking().Include(prod => prod.Categoria).ToListAsync();
        }

        public async Task<Produto> GetById(int Id)
        {
            return await _context.produtos.AsNoTracking().Where(prod => prod.Id == Id)
                                                         .Include(prod => prod.Categoria)
                                                         .FirstOrDefaultAsync();
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
