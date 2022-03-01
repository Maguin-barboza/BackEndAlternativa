using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using BackEndAlternativa.Domain.DTOs;
using BackEndAlternativa.Domain.Interfaces.Repositories;
using BackEndAlternativa.Domain.Interfaces.Services;
using BackEndAlternativa.Domain.Models;
using BackEndAlternativa.Domain.Results;


namespace BackEndAlternativa.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        //TODO: Retornar somente o DTO, e não a classe Result.
        public async Task<IEnumerable<ProdutoDTO>> GetAll()
        {
            IEnumerable<Produto> produtos = await _repository.Select();
            IEnumerable<ProdutoDTO> produtosDTO = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
            return produtosDTO;
        }

        public async Task<ProdutoDTO> GetById(int id)
        {
            ProdutoDTO produtoDTO = _mapper.Map<ProdutoDTO>(await _repository.Select(id));
            return produtoDTO;
        }

        public ProdutoDTO Add(ProdutoDTO produtoDTO)
        {
            Produto produto = _mapper.Map<Produto>(produtoDTO);
            produto = _repository.Insert(produto);

            return _mapper.Map<ProdutoDTO>(produto);
        }

        public ProdutoDTO Update(ProdutoDTO produtoDTO)
        {
            Produto produto = _mapper.Map<Produto>(produtoDTO);
            produto = _repository.Update(produto);

            return _mapper.Map<ProdutoDTO>(produto);
        }

        public ProdutoDTO Delete(ProdutoDTO produtoDTO)
        {
            Produto produto = _mapper.Map<Produto>(produtoDTO);
            produto = _repository.Delete(produto);

            return _mapper.Map<ProdutoDTO>(produto);
        }
    }
}
