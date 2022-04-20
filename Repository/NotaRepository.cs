using ControleCompras.Models;
using ControleCompras.Repository.Config;
using MongoDB.Driver;

namespace ControleCompras.Repository
{
	public class NotaRepository : MongoDbConfig<Nota>, INotaRepository
	{
		public NotaRepository(IConfiguration configuration) : base(configuration)
		{
		}

		public async Task<Nota> GetByDescription(string description)
		{
			return await (await MongoCollection.FindAsync(f => f.Description == description)).FirstOrDefaultAsync();

		}
	}
}
