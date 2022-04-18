﻿using ControleCompras.Models;
using ControleCompras.Repository;
using ControleCompras.Shared.Componentes;
using ControleCompras.Util;
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

		protected string Title { get; set; }
		protected Alert Alert { get; set; }
		protected Modal Modal { get; set; }

		protected override async Task OnInitializedAsync()
		{
			ListaSupermercados = new List<Supermercados>();
			Supermercados = new();
			if (Alert is not null) Alert.CloseMessage();
			await Buscar();
		}

		protected async Task Buscar()
		{
			ListaSupermercados = await _supermercadoRepository.Buscar();
		}
		protected async Task Salvar(EditContext e)
		{
			try
			{
				var supermercados = e.Model as Supermercados;

				if (string.IsNullOrEmpty(supermercados.Id))
				{
					await Inserir(supermercados);
				}
				else
				{
					await Editar(supermercados);
				}

				Supermercados = new();
				await Buscar();
			}
			catch (Exception ex)
			{
				Alert.ShowErrorMessage(ex.Message);
			}
		}

		private async Task Inserir(Supermercados supermercados)
		{
			await _supermercadoRepository.Inserir(supermercados);
			Alert.ShowSuccessMessage(Messages.Insert);
		}

		private async Task Editar(Supermercados supermercados)
		{
			await _supermercadoRepository.Editar(supermercados);
			Alert.ShowSuccessMessage(Messages.Update);
		}

		protected async Task Excluir(string id)
		{
			try
			{
				await _supermercadoRepository.Deletar(id);
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
				Supermercados = new();
				Title = "Cadastrar Novo Supermercado";
				Modal.Open();
			}
			catch (Exception ex)
			{
				Alert.ShowErrorMessage(ex.Message);
			}
		}

		protected void AtualizarObjetoParaEdicao(Supermercados supermercados)
		{
			Supermercados = supermercados;
			Title = "Editar Supermercado";
			Modal.Open();
		}
	}
}
