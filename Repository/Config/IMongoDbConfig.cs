using ControleCompras.Models;

namespace ControleCompras.Repository.Config
{
	public interface IMongoDbConfig<T> where T : EntityBase
	{
		Task<IEnumerable<T>> Get();

		Task<T> Get(string id);

		Task Insert(T obj);

		Task Update(T obj);

		Task Delete(string id);
	}
}
