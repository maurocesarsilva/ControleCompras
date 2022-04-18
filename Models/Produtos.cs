using ControleCompras.Configuration;
using System.ComponentModel.DataAnnotations;

namespace ControleCompras.Models
{
	[Collection(collection: "Produtos", dataBase: "ControleComprasDb")]
	public class Produtos : EntityBase
	{
		[Required(ErrorMessage ="Nome Obrigatório")]
		[MaxLength(20, ErrorMessage ="Campo {0} deve possuir no maximo 20 caracteres")]
		public string Nome { get; set; }
	}
}
