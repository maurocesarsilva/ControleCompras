using ControleCompras.Configuration;
using ControleCompras.Models;
using MongoDB.Driver;

namespace ControleCompras.Repository.Config
{
	public abstract class MongoDbConfig<T> where T : class
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
			var dataBaseAttribute = (DataBaseAttribute)Attribute.GetCustomAttribute(type, typeof(DataBaseAttribute));
			var collectionAttribute = (CollectionAttribute)Attribute.GetCustomAttribute(type, typeof(CollectionAttribute));

			if (dataBaseAttribute is null || collectionAttribute is null) { throw new Exception("DataBase e Collection não informados no objeto"); }


			return (dataBaseAttribute.DataBase, collectionAttribute.Collection);
		}
	}
}
