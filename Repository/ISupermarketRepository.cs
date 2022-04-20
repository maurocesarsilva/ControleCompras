using ControleCompras.Models;
using ControleCompras.Repository.Config;

namespace ControleCompras.Repository
{
	public interface ISupermarketRepository : IMongoDbConfig<Supermarket>
	{
		Task<Supermarket> GetByName(string nome);
	}
}
