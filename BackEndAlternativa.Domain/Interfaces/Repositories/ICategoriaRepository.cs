using System.Collections.Generic;
using System.Threading.Tasks;

using BackEndAlternativa.Domain.Models;

namespace BackEndAlternativa.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> Select();
        Task<Categoria> Select(int Id);

        Categoria Insert(Categoria categoria);
        Categoria Update(Categoria categoria);
        Categoria Delete(Categoria categoria);

    }
}
