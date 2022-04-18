using ControleCompras.Models;
using ControleCompras.Repository.Config;

namespace ControleCompras.Repository
{
	public interface IProdutosRepository : IMongoDbConfig<Produtos>
	{
	}
}
