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
            return Ok(await _service.GetAll());
        }


        // GET api/<CategoriaController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetById(id));
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaInput categoriaInput)
        {
            try
            {
                //TODO: Fazer Mapeamento de Inputs para DTOs.
                CategoriaDTO categoriaDTO = _mapper.Map<CategoriaDTO>(categoriaInput);
                categoriaDTO = await _service.Add(categoriaDTO);

                return Ok(new ResultOne<CategoriaDTO>() { item = categoriaDTO, Success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoriaInput categoriaInput)
        {
            try
            {
                CategoriaDTO categoria = await _service.GetById(id);

                if (categoria is null)
                    return BadRequest("categoria não foi encontrada.");

                CategoriaDTO categoriaUpdateDTO = _mapper.Map<CategoriaDTO>(categoriaInput);
                categoriaUpdateDTO = await _service.Update(categoriaUpdateDTO);

                return Ok(new ResultOne<CategoriaDTO> { item = categoriaUpdateDTO, Success = true });
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
                CategoriaDTO categoriaDTO = await _service.GetById(id);

                if (categoriaDTO is null)
                    return BadRequest("categoria não foi encontrada.");

                _service.Delete(categoriaDTO);

                return Ok(new ResultBase() { Success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
