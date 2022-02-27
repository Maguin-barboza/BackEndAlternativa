using System.Collections.Generic;
using System.Threading.Tasks;

using BackEndAlternativa.API.Data.Repositories.Filters;
using BackEndAlternativa.Domain.Models;

namespace BackEndAlternativa.API.Data.Repositories.Interfaces
{
    public interface IProdutoRepo
    {
        Task<IEnumerable<Produto>> GetAll(FilterProduto query);
        Task<Produto> GetById(int Id);

        void Insert(Produto produto);
        void Update(Produto produto);
        void Delete(Produto produto);
        bool SaveChanges();
    }
}
