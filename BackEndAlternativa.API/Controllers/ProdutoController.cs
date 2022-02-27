using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using BackEndAlternativa.API.Models;
using BackEndAlternativa.API.Data.Repositories.Interfaces;
using BackEndAlternativa.API.Controllers.DTOs.Queries;
using BackEndAlternativa.API.Controllers.DTOs.Commands;
using BackEndAlternativa.API.Data.Repositories.Filters;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAlternativa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepo _repository;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilterProduto query)
        {
            IEnumerable<Produto> produtos = await _repository.GetAll(query);
            return Ok(_mapper.Map<IEnumerable<ProdutoWithCategoriaDTO>>(produtos));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Produto produto = await _repository.GetById(id);
            return Ok(_mapper.Map<ProdutoWithCategoriaDTO>(produto));
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoAddDTO produtoDTO)
        {
            try
            {
                Produto produto = _mapper.Map<Produto>(produtoDTO);

                _repository.Insert(produto);
                _repository.SaveChanges();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProdutoController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProdutoUpdateDTO produtoDTO)
        {
            try
            {
                if (await ProdutoNotExists(produtoDTO.Id))
                    return BadRequest("Produto não encontrado");

                Produto produto = _mapper.Map<Produto>(produtoDTO);

                _repository.Update(produto);
                _repository.SaveChanges();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<bool> ProdutoNotExists(int id)
        {
            Produto produto = await _repository.GetById(id);

            return produto is null;
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Produto produto = await _repository.GetById(id);

                if (produto is null)
                    return BadRequest("Produto não encontrado");

                _repository.Delete(produto);
                _repository.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
