using ControleCompras.Models;
using ControleCompras.Repository.Config;

namespace ControleCompras.Repository
{
	public interface INotaRepository : IMongoDbConfig<Nota>
	{
		Task<Nota> GetByDescription(string description);
		Task<IEnumerable<Nota>> GetByProducts(IEnumerable<string> products);
	}
}
