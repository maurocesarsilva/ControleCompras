using ControleCompras.Repository;

namespace ControleCompras.Configuration
{
	public static class DependencyInjectionConfiguration
	{
		public static void DependencyInjection(this IServiceCollection services)
		{
			services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
			services.AddTransient<ISupermercadoRepository, SupermercadoRepository>();
			services.AddTransient<IProdutosRepository, ProdutosRepository>();
		}
	}
}
