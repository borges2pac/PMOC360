using PMOC360.Web.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Web.Models.Repository.Interfaces
{
	public interface IClienteRepository
	{
		List<ClienteModel> GetAllClientes(int empresaId);
		List<ClienteModel> GetClientesById(int id, int empresaId);
		string CadastrarCliente(ClienteModel model);
		string UpdateCliente(ClienteModel model);
		string DesativaCliente(int id, int empresaId, string user);
	}
}
