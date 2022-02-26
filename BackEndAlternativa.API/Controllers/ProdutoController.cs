using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using BackEndAlternativa.API.Models;
using BackEndAlternativa.API.Data.Repositories.Interfaces;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAlternativa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepo _repository;

        public ProdutoController(IProdutoRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

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

        [HttpGet("/byCategoriaId/{categoriaId}")]
        public async Task<IActionResult> GetByCategoria(int categoriaId)
        {
            return Ok(await _repository.GetByCategoria(categoriaId));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            try
            {
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Produto produto)
        {
            try
            {
                Produto produtoAux = await _repository.GetById(produto.Id);

                if (produtoAux is null)
                    return BadRequest("Produto não encontrado");

                _repository.Update(produto);
                _repository.SaveChanges();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Produto produtoAux = await _repository.GetById(id);

                if (produtoAux is null)
                    return BadRequest("Produto não encontrado");

                _repository.Delete(produtoAux);
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
