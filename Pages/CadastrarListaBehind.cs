using ControleCompras.Models;
using ControleCompras.Repository;
using ControleCompras.Services;
using ControleCompras.Shared.Componentes;
using ControleCompras.Util;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace ControleCompras.Pages
{
	public class CadastrarListaBehind : ComponentBase
	{
		[Inject]
		private IProductService _productService { get; set; }

		protected Alert Alert { get; set; }
		protected List<Product> ListProducts { get; set; }
		protected List<Product> ListProductsTabela { get; set; }
		protected List<Product> ListProductSelect { get; set; }
		protected string TextSearch { get; set; }

		protected override async Task OnInitializedAsync()
		{
			if (Alert is not null) Alert.CloseMessage();
			ListProducts = new List<Product>();
			ListProductsTabela = new List<Product>();
			ListProductSelect = new List<Product>();
		}
		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			try
			{
				if (firstRender is false) return;

				ListProducts = (await _productService.Get())?.ToList();
				ListProductsTabela = ListProducts;
				StateHasChanged();
			}
			catch (Exception ex)
			{
				Alert.ShowErrorMessage(ex.Message);
			}
		}

		protected void ChackSelectEvent(Product product, ChangeEventArgs args)
		{
			if (Convert.ToBoolean(args.Value))
			{
				ListProductSelect.Add(product);
			}
			else
			{
				ListProductSelect.Remove(product);
			}
		}

		protected void Search()
		{
			if (TextSearch is null) return;

			ListProductsTabela = ListProducts.Where(s => s.Name.ToUpper().Contains(TextSearch.ToUpper())).ToList();
		}

		protected void Analyze()
		{
			if (TextSearch is null) return;

			ListProductsTabela = ListProducts.Where(s => s.Name.ToUpper().Contains(TextSearch.ToUpper())).ToList();
		}

		protected string VerifyCheck(Product product)
		{
			return ListProductSelect.Contains(product) ? "checked" : null;
		}
	}
}
