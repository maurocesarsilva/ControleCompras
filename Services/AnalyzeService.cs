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


		public async Task<List<Analyse>> Analyze(List<Product> products)
		{
			var listAnalyses = new List<Analyse>();

			var productNames = products.Select(n => n.Name);

			var notas = await GetNotes(productNames);

			var grupSupermarket = notas.GroupBy(x => x.Supermarket);
			foreach (var grupotNota in grupSupermarket)
			{
				var nota = grupotNota.ToList();
				RemoveNonSelectedProducts(nota, productNames);
				AddProductsToAnalysisList(nota, listAnalyses, grupotNota);
			}

			CheckCheaperProduct(listAnalyses);

			return listAnalyses;
		}

		private void CheckCheaperProduct(List<Analyse> listAnalyses)
		{
			var dicProdMaisBarato = listAnalyses.GroupBy(g => g.Product).ToDictionary(x => x.Key, x => x.ToList().Min(m => m.Value));

			foreach (var item in listAnalyses)
			{
				item.Cheaper = dicProdMaisBarato[item.Product] == item.Value;
			}
		}

		private async Task<IEnumerable<Nota>> GetNotes(IEnumerable<string> productNames)
		{
			var notas = await _notaService.GetByProducts(productNames);
			if (notas.Any() is false) throw new Exception(String.Format(Messages.NotFound, "Nota"));

			return notas;
		}

		private void RemoveNonSelectedProducts(List<Nota> nota, IEnumerable<string> productNames)
		{
			nota.ForEach(x => x.NotaItens.RemoveAll(r => productNames.Contains(r.Product) is false));
		}

		private void AddProductsToAnalysisList(List<Nota> nota, List<Analyse> listAnalyses, IGrouping<string, Nota> grupotNota)
		{
			foreach (var item in nota.OrderByDescending(o => o.Date))
			{
				foreach (var notaItem in item.NotaItens)
				{
					var analyse = new Analyse { Supermarket = grupotNota.Key };
					analyse.Product = notaItem.Product;
					analyse.Value = notaItem.Valor;

					if (listAnalyses.Any(a => a.Supermarket == grupotNota.Key && a.Product == notaItem.Product) is false)
					{
						listAnalyses.Add(analyse);
					}
				}
			}
		}
	}

	public class Analyse
	{
		public string Product { get; set; }
		public string Supermarket { get; set; }
		public decimal Value { get; set; }
		public bool Cheaper { get; set; }
	}
}
