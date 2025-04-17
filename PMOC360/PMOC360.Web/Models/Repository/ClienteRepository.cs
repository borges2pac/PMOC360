using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PMOC360.Web.Models.Repository.Interfaces;
using PMOC360.Web.Models.Data;
using PMOC360.Web.Models.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Microsoft.Data.SqlClient.DataClassification;

namespace PMOC360.Web.Models.Repository
{
	public class ClienteRepository : IClienteRepository
	{
		private readonly IDapperRepository _dapper;

		public ClienteRepository(IDapperRepository dapper)
		{
			_dapper = dapper;
		}

		public string CadastrarCliente(ClienteModel model)
		{
			string output = string.Empty;

			try
			{
				var sprParams = new DynamicParameters();

				sprParams.Add("@nome", model.Nome, DbType.String);
				sprParams.Add("@documento", model.Documento, DbType.String);
				sprParams.Add("@email", model.Email, DbType.String);
				sprParams.Add("@telefone", model.Telefone, DbType.String);
				sprParams.Add("@responsavel", model.Responsavel, DbType.String);
				sprParams.Add("@endereco", model.Endereco, DbType.String);
				sprParams.Add("@numero", model.Numero, DbType.String);
				sprParams.Add("@complemento", model.Complemento, DbType.String);
				sprParams.Add("@bairro", model.Bairro, DbType.String);
				sprParams.Add("@cidade", model.Cidade, DbType.String);
				sprParams.Add("@estado", model.Estado, DbType.String);
				sprParams.Add("@cep", model.Cep, DbType.String);
				sprParams.Add("@empresa", model.Cod_Empresa, DbType.Int32);
				sprParams.Add("@user", model.User_Cad, DbType.String);

				var retorno = _dapper.execute_sp<int>($"spr_CADASTRAR_CLIENTE", sprParams, commandType: CommandType.StoredProcedure);

				switch (retorno)
				{
					case 0:
						output = "Cliente cadastrado com sucesso.";
						break;
					case -1:
						output = "Cliente já cadastrado.";
						break;
					case -2:
						output = "Número de documento já cadastrado.";
						break;
					case -3:
						output = "Não foi possível cadastrar o cliente, contate o suporte.";
						break;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}

		public string DesativaCliente(int id, int empresaId, string user)
		{
			string output = string.Empty;

			try
			{
				var sprParams = new DynamicParameters();
				sprParams.Add("@id", id, DbType.Int32);
				sprParams.Add("@empresaId", empresaId, DbType.Int32);
				sprParams.Add("@user", user, DbType.String);

				var retorno = _dapper.execute_sp<int>($"spr_DELETE_CLEINTE", sprParams, commandType: CommandType.StoredProcedure);

				switch (retorno)
				{
					case 0:
						output = "Cliente deletado com sucesso.";
						break;
					case -1:
						output = "Cliente não encontrado.";
						break;
					case -2:
						output = "Não foi possível deletar o cliente, contate o suporte.";
						break;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}

		public List<ClienteModel> GetAllClientes(int empresaId)
		{
			try
			{
				var sprParams = new DynamicParameters();

				sprParams.Add("@empresaId", empresaId, DbType.Int32);

				return _dapper.GetAll<ClienteModel>($"spr_GET_ALL_CLIENTES", sprParams, commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ClienteModel> GetClientesById(int id, int empresaId)
		{
			try
			{
				var sprParams = new DynamicParameters();

				sprParams.Add("@id", id, DbType.Int32);
				sprParams.Add("@empresaId", empresaId, DbType.Int32);

				return _dapper.GetAll<ClienteModel>($"spr_GET_CLIENTES", sprParams, commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string UpdateCliente(ClienteModel model)
		{
			string output = string.Empty;

			try
			{
				var sprParams = new DynamicParameters();

				sprParams.Add("@id", model.ID, DbType.Int32);
				sprParams.Add("@nome", model.Nome, DbType.String);
				sprParams.Add("@documento", model.Documento, DbType.String);
				sprParams.Add("@email", model.Email, DbType.String);
				sprParams.Add("@telefone", model.Telefone, DbType.String);
				sprParams.Add("@responsavel", model.Responsavel, DbType.String);
				sprParams.Add("@endereco", model.Endereco, DbType.String);
				sprParams.Add("@numero", model.Numero, DbType.String);
				sprParams.Add("@complemento", model.Complemento, DbType.String);
				sprParams.Add("@bairro", model.Bairro, DbType.String);
				sprParams.Add("@cidade", model.Cidade, DbType.String);
				sprParams.Add("@estado", model.Estado, DbType.String);
				sprParams.Add("@cep", model.Cep, DbType.String);
				sprParams.Add("@user", model.User_Cad, DbType.String);

				var retorno = _dapper.execute_sp<int>($"spr_CADASTRAR_CLIENTE", sprParams, commandType: CommandType.StoredProcedure);

				switch (retorno)
				{
					case 0:
						output = "Cliente atualizado com sucesso.";
						break;
					case -1:
						output = "Cliente não encontrado.";
						break;
					case -2:
						output = "Falha ao atualizar o cliente, contate o suporte.";
						break;
					case -3:
						output = "Não foi possível atualizar o cliente, contate o suporte.";
						break;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}
	}
}
