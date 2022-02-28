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
        public async Task<ResultMany<ProdutoDTO>> GetAll()
        {
            IEnumerable<ProdutoDTO> produtosDTO = _mapper.Map<IEnumerable<ProdutoDTO>>(_repository.Select());
            return new ResultMany<ProdutoDTO>() { items = produtosDTO, Success = true };
        }

        public async Task<ResultOne<ProdutoDTO>> GetById(int id)
        {
            ProdutoDTO produtoDTO = _mapper.Map<ProdutoDTO>(await _repository.Select(id));
            return new ResultOne<ProdutoDTO>() { item = produtoDTO, Success = true };
        }

        public ResultBase Add(ProdutoDTO produtoDTO)
        {
            Produto produto = _mapper.Map<Produto>(produtoDTO);
            produto = _repository.Insert(produto);

            return new ResultBase() { Messages = $"Produto {produto.Id} inserido com sucesso.", Success = true };
        }

        public ResultBase Update(ProdutoDTO produtoDTO)
        {
            Produto produto = _mapper.Map<Produto>(produtoDTO);
            produto = _repository.Update(produto);

            return new ResultBase() { Messages = $"Produto {produto.Id}, alterado com sucesso.", Success = true };
        }

        public async Task<ResultBase> Delete(int id)
        {
            Produto produto = await _repository.Select(id);
            _repository.Delete(produto);

            return new ResultBase() { Success = true, Messages = $"Produto {produto.Id} deletado com sucesso." };
        }
    }
}
