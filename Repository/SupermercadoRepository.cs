using ControleCompras.Models;
using ControleCompras.Repository.Config;
using MongoDB.Driver;

namespace ControleCompras.Repository
{
	public class SupermercadoRepository : MongoDbConfig<Supermercados>, ISupermercadoRepository
	{
		public SupermercadoRepository(IConfiguration configuration) : base(configuration) { }

	}
}
