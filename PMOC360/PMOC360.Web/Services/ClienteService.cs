using Newtonsoft.Json;
using PMOC360.COMMON;
using PMOC360.COMMON.Models;
using PMOC360.Web.ViewModels;

namespace PMOC360.Web.Services
{
	public class ClienteService
	{
		public IEnumerable<ClienteViewModel> GetClientes()
		{
			List<ClienteViewModel> clientes = new List<ClienteViewModel>();

			try
			{
				ParametrosApiModel parametros = new ParametrosApiModel()
				{
					ApiName = "Clientes",
					Rota = "ObterClientes"
				};

				var retornoExecucao = InterfaceAPI.ExecutaApiGet(parametros);

				var list = JsonConvert.DeserializeObject<IEnumerable<ClienteViewModel>>(retornoExecucao.Result.Content.ReadAsStringAsync().Result);

				return list;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
