using ControleCompras.Models;

namespace ControleCompras.Services
{
	public interface ISupermarketService
	{
		Task<IEnumerable<Supermarket>> Get();

		Task<Supermarket> Get(string id);

		Task Save(Supermarket supermercados);

		Task Delete(string id);
	}
}
