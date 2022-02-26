using BackEndAlternativa.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndAlternativa.API.Data.Repositories.Interfaces
{
    public interface IProdutoRepo
    {
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> GetById(int Id);
        Task<IEnumerable<Produto>> GetByCategoria(int CategoriaId);
        Task<IEnumerable<Produto>> GetByName(string Name);

        void Insert(Produto produto);
        void Update(Produto produto);
        void Delete(Produto produto);
        bool SaveChanges();
    }
}
