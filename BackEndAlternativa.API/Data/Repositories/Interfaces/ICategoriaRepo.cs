using System.Collections.Generic;
using System.Threading.Tasks;

using BackEndAlternativa.API.Data.Repositories.Filters;
using BackEndAlternativa.API.Models;

namespace BackEndAlternativa.API.Data.Repositories.Interfaces
{
    public interface ICategoriaRepo
    {
        Task<IEnumerable<Categoria>> GetAll(FilterCategoria query);
        Task<Categoria> GetById(int Id);

        void Insert(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(Categoria categoria);
        bool SaveChanges();

    }
}
