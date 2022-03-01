using AutoMapper;

using BackEndAlternativa.API.Controllers.Models.Input;
using BackEndAlternativa.Domain.DTOs;

namespace BackEndAlternativa.API.Controllers.Models
{
    public class ApiProfile: Profile
    {
        public ApiProfile()
        {
            CreateMap<CategoriaInput, CategoriaDTO>();
            CreateMap<ProdutoInput, ProdutoDTO>();
        }
    }
}
