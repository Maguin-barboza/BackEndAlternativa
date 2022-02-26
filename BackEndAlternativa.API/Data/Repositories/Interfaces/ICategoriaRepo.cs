using BackEndAlternativa.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndAlternativa.API.Data.Repositories.Interfaces
{
    public interface ICategoriaRepo
    {
        Task<IEnumerable<Categoria>> GetAll();
        Task<Categoria> GetById(int Id);
        Task<IEnumerable<Categoria>> GetByName(string Nome);
        Task<bool> HasProd(int Id);

        void Insert(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(Categoria categoria);
        bool SaveChanges();

    }
}
