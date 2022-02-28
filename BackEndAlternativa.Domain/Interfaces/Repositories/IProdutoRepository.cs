using System.Collections.Generic;
using System.Threading.Tasks;

using BackEndAlternativa.Domain.Models;

namespace BackEndAlternativa.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> Select();
        Task<Produto> Select(int Id);

        Produto Insert(Produto produto);
        Produto Update(Produto produto);
        void Delete(Produto produto);
    }
}
