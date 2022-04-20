using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ControleCompras.Models
{
	public class EntityBase
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		public DateTime Date { get; set; }

		public EntityBase()
		{
			Date = DateTime.Now;
		}
	}
}
