using AutoMapper;

using BackEndAlternativa.Domain.DTOs;
using BackEndAlternativa.Domain.Models;


namespace BackEndAlternativa.API.Controllers.DTOs.Mapper
{
    public class AlternativaProfile: Profile
    {
        public AlternativaProfile()
        {
            CreateMap<Produto,ProdutoDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        }
    }
}
