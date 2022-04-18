using ControleCompras.Repository;
using ControleCompras.Shared.Componentes;
using ControleCompras.Util;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace ControleCompras.Pages
{
	public class ProdutosBehind : ComponentBase
	{
		[Inject]
		private IProdutosRepository _produtoRepository { get; set; }

		protected IEnumerable<Models.Produtos> ListaProdutos;

		protected Models.Produtos Produtos;

		protected string Title { get; set; }
		protected Alert Alert { get; set; }
		protected Modal Modal { get; set; }

		protected override async Task OnInitializedAsync()
		{
			ListaProdutos = new List<Models.Produtos>();
			Produtos = new();
			if (Alert is not null) Alert.CloseMessage();
			await Buscar();
		}

		protected async Task Buscar()
		{
			ListaProdutos = await _produtoRepository.Buscar();
		}
		protected async Task Salvar(EditContext e)
		{
			try
			{
				var produtos = e.Model as Models.Produtos;

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

		private async Task Inserir(Models.Produtos produtos)
		{
			await _produtoRepository.Inserir(produtos);
			Alert.ShowSuccessMessage(Messages.Insert);
		}

		private async Task Editar(Models.Produtos produtos)
		{
			await _produtoRepository.Editar(produtos);
			Alert.ShowSuccessMessage(Messages.Update);
		}

		protected async Task Excluir(string id)
		{
			try
			{
				await _produtoRepository.Deletar(id);
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

		protected void AtualizarObjetoParaEdicao(Models.Produtos produtos)
		{
			Produtos = produtos;
			Title = "Editar Produto";
			Modal.Open();
		}
	}
}
