using System.Collections.Generic;
using System.Threading.Tasks;

using BackEndAlternativa.Domain.DTOs;
using BackEndAlternativa.Domain.Results;

namespace BackEndAlternativa.Domain.Interfaces.Services
{
    public interface ICategoriaService
    {
        Task<CategoriaDTO> GetAll();
        Task<CategoriaDTO> GetById(int id);

        Task<CategoriaDTO> Add(CategoriaDTO categoriaDTO);
        Task<CategoriaDTO> Update(CategoriaDTO categoriaDTO);
        Task<bool> Delete(CategoriaDTO categoriaDTO);
    }
}
