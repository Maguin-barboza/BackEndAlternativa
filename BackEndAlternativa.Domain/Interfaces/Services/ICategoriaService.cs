using System.Collections.Generic;
using System.Threading.Tasks;

using BackEndAlternativa.Domain.DTOs;

namespace BackEndAlternativa.Domain.Interfaces.Services
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> GetAll();
        Task<CategoriaDTO> GetById(int id);

        CategoriaDTO Add(CategoriaDTO categoriaDTO);
        CategoriaDTO Update(CategoriaDTO categoriaDTO);
        CategoriaDTO Delete(CategoriaDTO categoriaDTO);
    }
}
