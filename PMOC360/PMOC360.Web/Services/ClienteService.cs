using PMOC360.COMMON;
using PMOC360.COMMON.Models;

namespace PMOC360.Web.Services
{
	public class ClienteService
	{
		public async Task GetClientes()
		{
			try
			{
				ParametrosApiModel parametros = new ParametrosApiModel()
				{
					ApiName = "Clientes",
					Rota = "ObterClientes"
				};

				var retonroExecucao = await InterfaceAPI.ExecutaApiGet(parametros);
			}
			catch (Exception ex)
			{
			}
		}
	}
}
