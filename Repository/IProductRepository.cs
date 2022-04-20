using ControleCompras.Models;
using ControleCompras.Repository.Config;
using MongoDB.Driver;

namespace ControleCompras.Repository
{
	public interface IProductRepository : IMongoDbConfig<Product>
	{
		Task<Product> GetByName(string nome);

	}
}
