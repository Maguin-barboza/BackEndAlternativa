using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using BackEndAlternativa.Domain.DTOs;
using BackEndAlternativa.Domain.Interfaces.Repositories;
using BackEndAlternativa.Domain.Interfaces.Services;
using BackEndAlternativa.Domain.Models;
using BackEndAlternativa.Services.Utils.Exceptions;

namespace BackEndAlternativa.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoriaDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<CategoriaDTO>>(await _repository.Select());
        }

        public async Task<CategoriaDTO> GetById(int id)
        {
            return _mapper.Map<CategoriaDTO>(await _repository.Select(id));
        }

        public CategoriaDTO Add(CategoriaDTO categoriaDTO)
        {
            Categoria categoria = _mapper.Map<Categoria>(categoriaDTO);
            categoria = _repository.Insert(categoria);

            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public CategoriaDTO Update(CategoriaDTO categoriaDTO)
        {
            Categoria categoria = _mapper.Map<Categoria>(categoriaDTO);
            categoria = _repository.Update(categoria);

            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public CategoriaDTO Delete(CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO.Produtos.Count() > 0)
                throw new DeleteCategoryWithProductsException("Categoria não pode ser excluída pois contém produtos ligados à ela.\n" +
                                                              $"Exclua os produtos da categoria {categoriaDTO.Name} para prosseguir com a exclusão.");

            Categoria categoria = _mapper.Map<Categoria>(categoriaDTO);
            categoria = _repository.Delete(categoria);

            return _mapper.Map<CategoriaDTO>(categoria);
        }
    }
}
