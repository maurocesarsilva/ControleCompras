using ControleCompras.Repository;
using ControleCompras.Shared.Componentes;
using ControleCompras.Util;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace ControleCompras.Pages
{
	public class CadastrarListaBehind : ComponentBase
	{
		[Inject]
		private IProductRepository _produtoRepository { get; set; }

		protected IEnumerable<Models.Product> ListaProdutos;

		protected Models.Product Produtos;

		protected string Title { get; set; }
		protected Alert Alert { get; set; }
		protected Modal Modal { get; set; }

		protected override async Task OnInitializedAsync()
		{
			ListaProdutos = new List<Models.Product>();
			Produtos = new();
			if (Alert is not null) Alert.CloseMessage();
			await Buscar();
		}

		protected async Task Buscar()
		{
			ListaProdutos = await _produtoRepository.Get();
		}
		protected async Task Salvar(EditContext e)
		{
			try
			{
				var produtos = e.Model as Models.Product;

				if (string.IsNullOrEmpty(produtos.Id))
				{
					await Inserir(produtos);
				}
				else
				{
					await Editar(produtos);
				}

				Produtos = new();
				await Buscar();
			}
			catch (Exception ex)
			{
				Alert.ShowErrorMessage(ex.Message);
			}
		}

		private async Task Inserir(Models.Product produtos)
		{
			await _produtoRepository.Insert(produtos);
			Alert.ShowSuccessMessage(Messages.Insert);
		}

		private async Task Editar(Models.Product produtos)
		{
			await _produtoRepository.Update(produtos);
			Alert.ShowSuccessMessage(Messages.Update);
		}

		protected async Task Excluir(string id)
		{
			try
			{
				await _produtoRepository.Delete(id);
				await Buscar();
				Alert.ShowSuccessMessage(Messages.Delete);
			}
			catch (Exception ex)
			{
				Alert.ShowErrorMessage(ex.Message);
			}
		}

		protected void PrepararModalParaSalvar()
		{
			try
			{
				Produtos = new();
				Title = "Cadastrar Novo Produto";
				Modal.Open();
			}
			catch (Exception ex)
			{
				Alert.ShowErrorMessage(ex.Message);
			}
		}

		protected void AtualizarObjetoParaEdicao(Models.Product produtos)
		{
			Produtos = produtos;
			Title = "Editar Produto";
			Modal.Open();
		}
	}
}
