using ControleCompras.Models;

namespace ControleCompras.Services
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> Get();

		Task<Product> Get(string id);

		Task Save(Product supermercados);

		Task Delete(string id);
	}
}
