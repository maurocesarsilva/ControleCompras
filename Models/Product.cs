using ControleCompras.Configuration;
using System.ComponentModel.DataAnnotations;

namespace ControleCompras.Models
{
	[Collection(collection: "Product", dataBase: "PurchaseControlDb")]
	public class Product : EntityBase
	{
		[Required(ErrorMessage ="Nome Obrigatório")]
		[MaxLength(20, ErrorMessage ="Campo {0} deve possuir no maximo 20 caracteres")]
		public string Name { get; set; }
	}
}
