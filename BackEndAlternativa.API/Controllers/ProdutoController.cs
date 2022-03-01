using System;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using BackEndAlternativa.Domain.Interfaces.Services;
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
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoInput produtoInput)
        {
            try
            {
                ProdutoDTO produtoDTO = _mapper.Map<ProdutoDTO>(produtoInput);
                produtoDTO = _service.Add(produtoDTO);

                return Ok(produtoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProdutoInput produtoInput)
        {
            try
            {
                ProdutoDTO produtoDTO = await _service.GetById(id);
                if (produtoDTO is null)
                    return BadRequest("Produto não encontrado");

                produtoDTO = _mapper.Map<ProdutoDTO>(produtoInput);
                produtoDTO.Id = id;
                produtoDTO = _service.Update(produtoDTO);

                return Ok(produtoDTO);
            }
            catch (Exception ex)
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
                ProdutoDTO produtoDTO = await _service.GetById(id);

                if (produtoDTO is null)
                    return BadRequest("Produto não encontrado.");

                produtoDTO = _service.Delete(produtoDTO);

                return Ok(produtoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
