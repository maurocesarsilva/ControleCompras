using ControleCompras.Configuration;
using ControleCompras.Models;
using MongoDB.Driver;

namespace ControleCompras.Repository.Config
{
	public abstract class MongoDbConfig<T> : IMongoDbConfig<T> where T : EntityBase
	{
		private readonly IConfiguration _configuration;
		public IMongoCollection<T> MongoCollection { get; set; }

		public MongoDbConfig(IConfiguration configuration)
		{
			_configuration = configuration;
			var connectionString = _configuration.GetConnectionString("DefaultConnection");

			(string dataBase, string collection) = GetDataConnection();

			MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
			var client = new MongoClient(settings);
			MongoCollection = client.GetDatabase(dataBase).GetCollection<T>(collection);
		}

		private (string, string) GetDataConnection()
		{
			var type = typeof(T);
			var collectionAttribute = (CollectionAttribute)Attribute.GetCustomAttribute(type, typeof(CollectionAttribute));

			if (collectionAttribute is null) { throw new Exception("DataBase e Collection não informados no objeto"); }

			return (collectionAttribute.DataBase, collectionAttribute.Collection);
		}

		public async Task<IEnumerable<T>> Get()
		{
			return (await MongoCollection.AsQueryable().ToListAsync());
		}

		public async Task<T> Get(string id)
		{
			return await (await MongoCollection.FindAsync(f => f.Id == id)).FirstOrDefaultAsync();
		}

		public async Task Insert(T obj)
		{
			await MongoCollection.InsertOneAsync(obj);
		}
		public async Task Update(T obj)
		{
			await MongoCollection.ReplaceOneAsync(x => x.Id == obj.Id, obj);
		}

		public async Task Delete(string id)
		{
			await MongoCollection.DeleteOneAsync(x => x.Id == id);
		}
	}
}
