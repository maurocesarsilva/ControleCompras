﻿using ControleCompras.Models;
using ControleCompras.Repository.Config;

namespace ControleCompras.Repository
{
	public interface ISupermercadoRepository : IMongoDbConfig<Supermercados>
	{
	}
}
