using ControleCompras.Models;
using ControleCompras.Util;

namespace ControleCompras.Services
{
	public class AnalyzeService : IAnalyzeService
	{
		public AnalyzeService(INotaService notaService)
		{
			_notaService = notaService;
		}

		private INotaService _notaService { get; set; }


		public async Task Analyze(List<Product> products)
		{
			var productNames = products.Select(n => n.Name);

			//buscar notas
			var notas = await _notaService.GetByProducts(productNames);
			if (notas.Any() is false) throw new Exception(String.Format(Messages.NotFound, "Nota"));

			var listAnalyses = new List<Analyse>();


			var grupoSupermarket = notas.GroupBy(x => x.Supermarket);
			foreach (var grupotNota in grupoSupermarket)
			{
				var analyse = new Analyse { Supermarket = grupotNota.Key };

				var nota = grupotNota.ToList();

				//remove notas mais antigas
				var dateNotaMaisRecente = nota.Max(m => m.Date);
				nota.RemoveAll(r => r.Date != dateNotaMaisRecente);

				//remover os produtos não selecionados da lista
				nota.ForEach(x => x.NotaItens.RemoveAll(r => productNames.Contains(r.Product) is false));

				//agrupar por produtos
				var groupProdutc = nota.SelectMany(s => s.NotaItens).GroupBy(g => g.Product);
				foreach (var grupoProduct in groupProdutc)
				{
					var product = grupoProduct.ToList().FirstOrDefault();
					analyse.Product = product.Product;
					analyse.Valor = product.Valor;
				}
			}


			throw new NotImplementedException();
		}
	}

	public class Analyse
	{
		public string Product { get; set; }
		public string Supermarket { get; set; }
		public decimal Valor { get; set; }
	}
}
