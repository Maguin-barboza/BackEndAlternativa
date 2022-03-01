using Microsoft.Extensions.DependencyInjection;

using BackEndAlternativa.Domain.Interfaces.Services;
using BackEndAlternativa.Services;

namespace BackEndAlternativa.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICategoriaService, CategoriaService>();
            serviceCollection.AddTransient<IProdutoService, ProdutoService>();
        }
    }
}
