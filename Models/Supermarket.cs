using ControleCompras.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ControleCompras.Models
{
	[Collection(collection: "Supermarket", dataBase: "PurchaseControlDb")]
	public class Supermarket : EntityBase
	{
		[Required(ErrorMessage ="Nome Obrigatório")]
		[MaxLength(20, ErrorMessage ="Campo {0} deve possuir no maximo 20 caracteres")]
		public string Name { get; set; }
	}
}
