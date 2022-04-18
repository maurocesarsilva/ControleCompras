using ControleCompras.Models;
using ControleCompras.Repository.Config;
using MongoDB.Driver;

namespace ControleCompras.Repository
{
	public class ControleComprasDb : MongoDbConfig<Supermercados>, IControleComprasDb
	{
		public ControleComprasDb(IConfiguration configuration) : base(configuration) { }

		public async Task<IEnumerable<Supermercados>> Buscar()
		{
			return await MongoCollection.AsQueryable().ToListAsync();
		}

		public async Task<Supermercados> Buscar(string id)
		{
			return await (await MongoCollection.FindAsync(f => f.Id == id)).FirstOrDefaultAsync();
		}

		public async Task Inserir(Supermercados supermercado)
		{
			await MongoCollection.InsertOneAsync(supermercado);
		}

		public async Task Editar(Supermercados supermercado)
		{
			var up = Builders<Supermercados>.Update.Set(x => x.Nome, supermercado.Nome);
			await MongoCollection.UpdateOneAsync(x => x.Id == supermercado.Id, up);
		}

		public async Task Deletar(string id)
		{
			await MongoCollection.DeleteOneAsync(x => x.Id == id);
		}
	}
}
