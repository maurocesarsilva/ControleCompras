using ControleCompras.Configuration;
using ControleCompras.Util;
using System.ComponentModel.DataAnnotations;

namespace ControleCompras.Models
{
	[Collection(collection: "Nota", dataBase: "PurchaseControlDb")]
	public class Nota : EntityBase
	{
		public Nota()
		{
			NotaItens ??= new();
		}

		[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = ErrorMessageConstant.Required)]
		[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = ErrorMessageConstant.NumMaxChar)]
		public string Description { get; set; }

		[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = ErrorMessageConstant.Required)]
		public string Supermarket { get; set; }

		public List<NotaItens> NotaItens { get; set; }
	}

	public class NotaItens
	{
		[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = ErrorMessageConstant.Required)]
		public string Product { get; set; }

		[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = ErrorMessageConstant.Required)]
		[Range(0.01, int.MaxValue, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = ErrorMessageConstant.ValueInvalid)]
		public decimal Valor { get; set; }
	}
}
