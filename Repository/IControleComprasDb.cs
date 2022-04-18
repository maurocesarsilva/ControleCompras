using ControleCompras.Models;

namespace ControleCompras.Repository
{
	public interface IControleComprasDb
	{
		Task<IEnumerable<Supermercados>> Buscar();

		Task<Supermercados> Buscar(string id);

		Task Inserir(Supermercados supermercado);

		Task Editar(Supermercados supermercado);

		Task Deletar(string id);
	}
}
