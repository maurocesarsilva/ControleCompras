using ControleCompras.Models;
using ControleCompras.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace ControleCompras.Pages
{
	public class IndexBehind : ComponentBase
	{
		[Inject]
		private ISupermercadoRepository _supermercadoRepository { get; set; }

		protected IEnumerable<Supermercados> ListaSupermercados;

		protected Supermercados Supermercados;

		protected string Mensagem;

		protected override async Task OnInitializedAsync()
		{
			ListaSupermercados = new List<Supermercados>();
			Supermercados = new();
			Mensagem = String.Empty;

			await Buscar();
		}

		protected async Task Buscar()
		{
			ListaSupermercados = await _supermercadoRepository.Buscar();
		}
		protected async Task Salvar(EditContext e)
		{
			var supermercados = e.Model as Supermercados;

			if (string.IsNullOrEmpty(supermercados.Id))
			{
			  await	Inserir(supermercados);
			}
			else
			{
				await Editar(supermercados);
			}

			Supermercados = new();
			await Buscar();
		}

		private async Task Inserir(Supermercados supermercados)
		{
			await _supermercadoRepository.Inserir(supermercados);
			Mensagem = "Inserido com Sucesso";
		}

		private async Task Editar(Supermercados supermercados)
		{
			await _supermercadoRepository.Editar(supermercados);
			Mensagem = "Editado com Sucesso";
		}

		protected async Task Excluir(string id)
		{
			await _supermercadoRepository.Deletar(id);
			await Buscar();
			Mensagem = "Excluido com Sucesso";
		}

		protected void AtualizarObjetoParaEdicao(Supermercados supermercados)
		{
			Supermercados = supermercados;
		}
	}
}
