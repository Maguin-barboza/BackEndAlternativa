using System.Collections.Generic;
using System.Threading.Tasks;

using BackEndAlternativa.Domain.DTOs;
using BackEndAlternativa.Domain.Results;


namespace BackEndAlternativa.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetAll();
        Task<ProdutoDTO> GetById(int id);

        ProdutoDTO Add(ProdutoDTO produtoDTO);
        ProdutoDTO Update(ProdutoDTO produtoDTO);
        ProdutoDTO Delete(ProdutoDTO produtoDTO);
    }
}
