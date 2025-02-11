using B.OS.API.Models;

namespace B.OS.API.Services.Interfaces
{
	public interface IClientesService
	{
		IEnumerable<Cliente> GetAllClientes();

		Cliente GetCliente(int id);

		int InsertCliente(Cliente cliente);

		bool UpdateCliente(int id, Cliente cliente);

		bool DeleteCliente(int id);
	}
}
