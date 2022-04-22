using ControleCompras.Repository;
using ControleCompras.Services;

namespace ControleCompras.Configuration
{
	public static class DependencyInjectionConfiguration
	{
		public static void DependencyInjection(this IServiceCollection services)
		{
			services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
			services.AddTransient<ISupermarketRepository, SupermermarketRepository>();
			services.AddTransient<IProductRepository, ProductRepository>();
			services.AddTransient<ISupermarketService, SupermarketService>();
			services.AddTransient<IProductService, ProductService>();
			services.AddTransient<INotaRepository, NotaRepository>();
			services.AddTransient<INotaService, NotaService>();
			services.AddTransient<IAnalyzeService, AnalyzeService>();
		}
	}
}
