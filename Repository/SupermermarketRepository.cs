using ControleCompras.Models;
using ControleCompras.Repository.Config;
using MongoDB.Driver;

namespace ControleCompras.Repository
{
	public class SupermermarketRepository : MongoDbConfig<Supermarket>, ISupermarketRepository
	{
		public SupermermarketRepository(IConfiguration configuration) : base(configuration) { }

		public async Task<Supermarket> GetByName(string nome)
		{
			return await (await MongoCollection.FindAsync(f => f.Name == nome)).FirstOrDefaultAsync();
		}
	}
}
