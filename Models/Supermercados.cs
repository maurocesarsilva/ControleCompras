using ControleCompras.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ControleCompras.Models
{
	[Collection(collection: "Supermercados", dataBase: "ControleComprasDb")]
	public class Supermercados : EntityBase
	{
		[Required(ErrorMessage ="Nome Obrigatório")]
		[MaxLength(20, ErrorMessage ="Campo { } deve possuir no maximo 20 caracteres")]
		public string Nome { get; set; }
	}
}
