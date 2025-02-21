using PMOC360.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Data
{
	public interface ISqlExecutor
	{
		//Login
		Task<DataTable> GetUserProfile(string login);
		Task<string> GetHashLogin(string login);

		//Clientes
		DataTable GetClientes(int? id);
		string CadastrarClientes(ClienteModel model);
		string UpdateCliente(ClienteModel model);
		string DesativaCliente(int id, string user);

		//Equipamentos
		DataTable GetEquipamentos(int clienteId);
		bool CadastrarEquipamentos(EquipamentoModel model);

		//Tecnicos
		bool CadastrarTecnico(TecnicoModel model);
		DataTable GetTecnicos();

		//Pmoc Modelo
		int CadastrarModelo(PmocModeloModel model);
		bool CadastrarItensModelo(ModeloItensModel model);
		DataTable ImportarListaPmocModelo(int id);
		DataTable ImportarPmocModelo(int id);
		DataTable ImportarListaPmocPorModelo(int id);
		DataTable ImportarListaPmocPorId(int id);		

		//Pmoc Plano
		bool CadastrarPlano(PmocPlanoModel model);
		DataTable ImportarListaPmocPlano(int id);
		DataTable ImportarPmocPlano(int id);

		//Pmoc Controle
	}
}
