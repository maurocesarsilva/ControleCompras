using ControleCompras.Models;

namespace ControleCompras.Services
{
	public interface IAnalyzeService
	{
		Task<List<Analyse>> Analyze(List<Product> products);
	}
}
