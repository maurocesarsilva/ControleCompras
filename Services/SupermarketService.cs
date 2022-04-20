using ControleCompras.Models;
using ControleCompras.Repository;
using ControleCompras.Util;

namespace ControleCompras.Services
{
	public class SupermarketService : ISupermarketService
	{

		private readonly ISupermarketRepository _supermercadoRepository;

		public SupermarketService(ISupermarketRepository supermercadoRepository)
		{
			_supermercadoRepository = supermercadoRepository;
		}

		public async Task<IEnumerable<Supermarket>> Get()
		{
			return await _supermercadoRepository.Get();
		}

		public async Task<Supermarket> Get(string id)
		{
			return await _supermercadoRepository.Get(id);
		}

		public async Task Delete(string id)
		{
			await _supermercadoRepository.Delete(id);
		}

		public async Task Save(Supermarket supermarket)
		{
			if (string.IsNullOrEmpty(supermarket.Id))
			{
				var supermarketResult = await _supermercadoRepository.GetByName(supermarket.Name);

				if (supermarketResult is not null) { throw new Exception(String.Format(Messages.ExisteRegister, "Supermercado")); }

				await _supermercadoRepository.Insert(supermarket);
			}
			else
			{
				await _supermercadoRepository.Update(supermarket);
			}
		}
	}
}
