using BackEndAlternativa.API.Data;
using BackEndAlternativa.API.Data.Repositories;
using BackEndAlternativa.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndAlternativa.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependeciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICategoriaRepository, CategoriaRepo>();
            serviceCollection.AddScoped<IProdutoRepository, ProdutoRepo>();

            //serviceCollection.AddDbContext<AlternativaContext>(option =>
            //    option.U)
        }
    }
}
