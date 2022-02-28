using System.Collections.Generic;
using System.Threading.Tasks;

using BackEndAlternativa.Domain.DTOs;
using BackEndAlternativa.Domain.Results;

namespace BackEndAlternativa.Domain.Interfaces.Services
{
    public interface ICategoriaService
    {
        Task<ResultMany<CategoriaDTO>> GetAll();
        Task<ResultOne<CategoriaDTO>> GetById(int id);

        Task<ResultBase> Add(CategoriaDTO categoriaDTO);
        Task<ResultBase> Update(CategoriaDTO categoriaDTO);
        Task<ResultBase> Delete(int Id);
    }
}
