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

        CategoriaDTO Add(CategoriaDTO categoriaDTO);
        CategoriaDTO Update(CategoriaDTO categoriaDTO);
        CategoriaDTO Delete(CategoriaDTO categoriaDTO);
    }
}
