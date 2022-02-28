using System;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using BackEndAlternativa.Domain.Interfaces.Services;
using BackEndAlternativa.Domain.Results;
using BackEndAlternativa.Domain.DTOs;
using BackEndAlternativa.API.Controllers.Models.Input;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAlternativa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResultMany<ProdutoDTO> result = await _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            ResultOne<ProdutoDTO> result = await _service.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoInput produtoInput)
        {
            ResultBase result = new ResultBase();
            try
            {
                ProdutoDTO produtoDTO = _mapper.Map<ProdutoDTO>(produtoInput);

                result = await _service.Add(produtoDTO);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProdutoInput produtoInput)
        {
            ResultBase result = new ResultBase();

            try
            {
                if (await ProdutoNotExists(id))
                    return BadRequest("Produto não encontrado");

                ProdutoDTO produtoDTO = _mapper.Map<ProdutoDTO>(produtoInput);

                result = await _service.Update(produtoDTO);

                return Ok(result);
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
            ResultBase result = new ResultBase();

            try
            {
                if (await ProdutoNotExists(id))
                    return BadRequest("Produto não encontrado.");

                result = await _service.Delete(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<bool> ProdutoNotExists(int id)
        {
            ResultOne<ProdutoDTO> result = await _service.GetById(id);

            return result.item is null;
        }
    }
}
