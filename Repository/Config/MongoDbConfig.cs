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

			var nameCollection = typeof(T).Name;
			var dataBaseName = GetType().Name.Split("`")[0];

			MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
			var cliente = new MongoClient(settings);
			MongoCollection = cliente.GetDatabase(dataBaseName).GetCollection<T>(nameCollection);
		}
	}
}
