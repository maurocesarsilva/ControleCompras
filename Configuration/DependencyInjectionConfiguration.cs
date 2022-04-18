using ControleCompras.Repository;

namespace ControleCompras.Configuration
{
	public static class DependencyInjectionConfiguration
	{
		public static void DependencyInjection(this IServiceCollection services)
		{
			services.AddTransient<IControleComprasDb, ControleComprasDb>();
		}
	}
}
