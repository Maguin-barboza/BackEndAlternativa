using System.Threading.Tasks;

using BackEndAlternativa.Domain.DTOs;
using BackEndAlternativa.Domain.Results;


namespace BackEndAlternativa.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<ResultMany<ProdutoDTO>> GetAll();
        Task<ResultOne<ProdutoDTO>> GetById(int id);

        Task<ResultBase> Add(ProdutoDTO produtoDTO);
        Task<ResultBase> Update(ProdutoDTO produtoDTO);
        Task<ResultBase> Delete(int id);
    }
}
