using AutoMapper;

using BackEndAlternativa.API.Controllers.DTOs.Commands;
using BackEndAlternativa.API.Controllers.DTOs.Queries;
using BackEndAlternativa.Domain.Models;
using System;

namespace BackEndAlternativa.API.Controllers.DTOs.Mapper
{
    public class AlternativaProfile: Profile
    {
        public AlternativaProfile()
        {
            CreateQueriesMaps();
            CreateCommandsMaps();
        }

        private void CreateQueriesMaps()
        {
            CreateMap<Categoria, CategoriaWithoutProdutosDTO>();
            CreateMap<Categoria, CategoriaWithProdutosDTO>();
            CreateMap<Produto, ProdutoWithCategoriaDTO>();
        }

        private void CreateCommandsMaps()
        {
            CreateMap<CategoriaAddDTO, Categoria>();
            CreateMap<CategoriaUpdateDTO, Categoria>();

            CreateMap<ProdutoAddDTO, Produto>();
            CreateMap<ProdutoUpdateDTO, Produto>();
        }
    }
}
