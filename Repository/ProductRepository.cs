using ControleCompras.Models;
using ControleCompras.Repository.Config;
using MongoDB.Driver;

namespace ControleCompras.Repository
{
	public class ProductRepository : MongoDbConfig<Product>, IProductRepository
	{
		public ProductRepository(IConfiguration configuration) : base(configuration)
		{
		}
		public async Task<Product> GetByName(string nome)
		{
			return await (await MongoCollection.FindAsync(f => f.Name == nome)).FirstOrDefaultAsync();
		}
	}
}
