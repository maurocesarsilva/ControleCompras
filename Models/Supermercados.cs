using ControleCompras.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ControleCompras.Models
{
	[DataBase(dataBase: "ControleComprasDb")]
	[Collection(collection: "Supermercados")]
	public class Supermercados
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[Required(ErrorMessage ="Nome Obrigatório")]
		[MaxLength(20, ErrorMessage ="Campo deve possuir no maximo 20 caracteres")]
		public string Nome { get; set; }
	}
}
