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

		public async Task<IEnumerable<Nota>> GetByProducts(IEnumerable<string> products)
		{
			return (await MongoCollection.AsQueryable().ToListAsync()).Where(w => w.NotaItens.Where(n => products.Contains(n.Product)).Any());
		}
	}
}
