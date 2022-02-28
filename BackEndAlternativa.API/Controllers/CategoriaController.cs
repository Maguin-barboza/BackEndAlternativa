using System;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using BackEndAlternativa.Domain.Interfaces.Services;
using BackEndAlternativa.Domain.DTOs;
using BackEndAlternativa.Domain.Results;
using BackEndAlternativa.API.Controllers.Models.Input;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAlternativa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResultMany<CategoriaDTO> result = await _service.GetAll();
            return Ok(result);
        }


        // GET api/<CategoriaController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            ResultOne<CategoriaDTO> result = await _service.GetById(id);
            return Ok(result);
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaInput categoriaInput)
        {
            ResultBase result = new ResultBase();

            try
            {
                CategoriaDTO categoriaDTO = _mapper.Map<CategoriaDTO>(categoriaInput);
                result = await _service.Add(categoriaDTO);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("Id")]
        public async Task<IActionResult> Put(int Id, [FromBody] CategoriaInput categoriaInput)
        {
            ResultBase result = new ResultBase();

            try
            {
                if (await CategoriaNotExists(Id))
                    throw new Exception("Categoria não encontrada.");

                CategoriaDTO categoriaUpdateDTO = _mapper.Map<CategoriaDTO>(categoriaInput);
                result = await _service.Update(categoriaUpdateDTO);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            ResultBase result = new ResultBase();

            try
            {
                if (await CategoriaNotExists(Id))
                    throw new Exception("Categoria não encontrada.");

                result = await _service.Delete(Id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<bool> CategoriaNotExists(int id)
        {
            ResultOne<CategoriaDTO> resultCategoria = await _service.GetById(id);
            return resultCategoria.item is null;
        }
    }
}
