using AutoMapper;

using BackEndAlternativa.API.Controllers.Models.Input;
using BackEndAlternativa.Domain.DTOs;
using BackEndAlternativa.Domain.Models;

namespace BackEndAlternativa.API.Controllers.Models
{
    public class AlternativaProfile: Profile
    {
        public AlternativaProfile()
        {
            CreateMap<CategoriaInput, CategoriaDTO>();
            CreateMap<ProdutoInput, ProdutoDTO>().ForMember(dest => dest.CategoriaId, opt => opt.MapFrom(src => src.Category_Id));

            //CreateMap<Produto, ProdutoDTO>().ForMember(dest => dest.CategoriaId, opt => opt.MapFrom(src => src.CategoriaId)).ReverseMap();
            CreateMap<Produto, ProdutoDTO>();
            CreateMap<ProdutoDTO, Produto>();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        }
    }
}
