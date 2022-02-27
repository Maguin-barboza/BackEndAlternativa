using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using BackEndAlternativa.API.Data.Repositories.Interfaces;
using BackEndAlternativa.Domain.Models;
using BackEndAlternativa.API.Controllers.DTOs.Queries;
using BackEndAlternativa.API.Controllers.DTOs.Commands;
using BackEndAlternativa.API.Data.Repositories.Filters;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAlternativa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepo _repository;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaRepo repository, IMapper mapper)
        {
           _repository = repository;
           _mapper = mapper;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilterCategoria query)
        {
            IEnumerable<Categoria> categorias = await _repository.GetAll(query);
            return Ok(_mapper.Map<IEnumerable<CategoriaWithoutProdutosDTO>>(categorias));

        }


        // GET api/<CategoriaController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Categoria categoria = await _repository.GetById(id);
            return Ok(_mapper.Map<CategoriaWithProdutosDTO>(categoria));
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoriaAddDTO categoriaDTO)
        {
            try
            {
                Categoria categoria = _mapper.Map<Categoria>(categoriaDTO);

                _repository.Insert(categoria);
                _repository.SaveChanges();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CategoriaController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoriaUpdateDTO categoriaDTO)
        {
            try
            {
                if (await CategoriaNotExists(categoriaDTO.Id))
                    return BadRequest("Categoria não encontrada.");

                Categoria categoria = _mapper.Map<Categoria>(categoriaDTO);

                _repository.Update(categoria);
                _repository.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Categoria categoria = await _repository.GetById(id);
                //TODO: Criar e lançar uma exception personalizada para estes casos. Ex: NotFoundException ou CanNotDeleteException
                if (categoria is null)
                    return BadRequest("Categoria não encontrada");

                if(categoria.Produtos.Count() > 0)
                    return BadRequest("Categoria está ligada a produtos.\n" +
                                      "Favor excluir os produtos dessa categoria para prosseguir com a exclusão.");
                

                _repository.Delete(categoria);
                _repository.SaveChanges();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<bool> CategoriaNotExists(int id)
        {
            Categoria categoria = await _repository.GetById(id);
            return (categoria is null);
        }
    }
}
