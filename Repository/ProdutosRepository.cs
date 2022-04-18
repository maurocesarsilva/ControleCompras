using ControleCompras.Models;
using ControleCompras.Repository.Config;

namespace ControleCompras.Repository
{
	public class ProdutosRepository : MongoDbConfig<Produtos>, IProdutosRepository
	{
		public ProdutosRepository(IConfiguration configuration) : base(configuration)
		{
		}
	}
}
