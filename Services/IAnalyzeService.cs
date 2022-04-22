using ControleCompras.Models;

namespace ControleCompras.Services
{
	public interface IAnalyzeService
	{
		Task Analyze(List<Product> products);
	}
}
