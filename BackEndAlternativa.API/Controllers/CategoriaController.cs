using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using BackEndAlternativa.API.Data.Repositories.Interfaces;
using BackEndAlternativa.API.Models;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAlternativa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepo _repository;

        public CategoriaController(ICategoriaRepo repository)
        {
           _repository = repository;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //TODO: Avisar, em todos os métodos Get, quando não encontrar o produto encontrado. (Verificar a melhor opção para mensagem)
            return Ok(await _repository.GetAll());
        }


        // GET api/<CategoriaController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.GetById(id));
        }

        [HttpGet("{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            return Ok(await _repository.GetByName(nome));
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            try
            {
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
        public async Task<IActionResult> Put([FromBody] Categoria categoria)
        {
            try
            {
                Categoria categoriaAux = await _repository.GetById(categoria.Id);

                if (categoriaAux is null)
                    return BadRequest("Categoria não encontrada.");
                
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
                Categoria categoriaAux = await _repository.GetById(id);

                //TODO: Criar e lançar uma exception personalizada para estes casos. Ex: NotFoundException ou CanNotDeleteException
                if (categoriaAux is null)
                    return BadRequest("Categoria não encontrada");

                if(categoriaAux.produtos.Count() > 0)
                {
                    return BadRequest("Categoria está ligada a produtos.\n" +
                                      "Favor excluir os produtos dessa categoria para prosseguir com a exclusão.");
                }
                    

                _repository.Delete(categoriaAux);
                _repository.SaveChanges();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
