using ControleCompras.Models;

namespace ControleCompras.Repository.Config
{
	public interface IMongoDbConfig<T> where T : EntityBase
	{
		Task<IEnumerable<T>> Buscar();

		Task<T> Buscar(string id);

		Task Inserir(T obj);

		Task Editar(T obj);

		Task Deletar(string id);
	}
}
