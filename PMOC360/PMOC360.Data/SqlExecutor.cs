using Microsoft.Extensions.Configuration;
using PMOC360.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Data
{
	public class SqlExecutor : ISqlExecutor
	{
		private readonly string _connectionString;

		public SqlExecutor(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("acessoDBPMOC");
		}

		public string CadastrarClientes(ClienteModel model)
		{
			string output = string.Empty;

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand("spr_CADASTRAR_CLIENTE", connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(new SqlParameter("@nome", model.Nome));
						command.Parameters.Add(new SqlParameter("@documento", model.Documento));
						command.Parameters.Add(new SqlParameter("@email", model.Email));
						command.Parameters.Add(new SqlParameter("@telefone", model.Telefone));
						command.Parameters.Add(new SqlParameter("@responsavel", model.Responsavel));
						command.Parameters.Add(new SqlParameter("@endereco", model.Endereco));
						command.Parameters.Add(new SqlParameter("@numero", model.Numero));
						command.Parameters.Add(new SqlParameter("@complemento", model.Complemento));
						command.Parameters.Add(new SqlParameter("@bairro", model.Bairro));
						command.Parameters.Add(new SqlParameter("@cidade", model.Cidade));
						command.Parameters.Add(new SqlParameter("@estado", model.Estado));
						command.Parameters.Add(new SqlParameter("@cep", model.Cep));
						command.Parameters.Add(new SqlParameter("@empresa", model.EmpresaId));
						command.Parameters.Add(new SqlParameter("@user", model.UserCad));

						int retorno = command.ExecuteNonQuery();

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
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}

		public bool CadastrarEquipamentos(EquipamentoModel model)
		{
			bool output = false;

			try
			{
				using (SqlConnection conn = new SqlConnection(_connectionString))
				{
					conn.Open();

					using (SqlCommand command = new SqlCommand("spr_CADASTRAR_EQUIPAMENTO", conn))
					{
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(new SqlParameter("@clienteId", model.ClienteID));
						command.Parameters.Add(new SqlParameter("@equipamento", model.Equipamento));
						command.Parameters.Add(new SqlParameter("@fabricante", model.Fabricante));
						command.Parameters.Add(new SqlParameter("@modelo", model.Modelo));
						command.Parameters.Add(new SqlParameter("@potencia", model.Potencia));
						command.Parameters.Add(new SqlParameter("@serie", model.Serie));
						command.Parameters.Add(new SqlParameter("@tag", model.Tag));
						command.Parameters.Add(new SqlParameter("@tipo", model.TipoAtividade));
						command.Parameters.Add(new SqlParameter("@ambiente", model.Ambiente));
						command.Parameters.Add(new SqlParameter("@fixos", model.Fixos));
						command.Parameters.Add(new SqlParameter("@flutuantes", model.Flutuantes));
						command.Parameters.Add(new SqlParameter("@modeloId", model.PmocModeloID));
						command.Parameters.Add(new SqlParameter("@codigo", model.barCode));
						command.Parameters.Add(new SqlParameter("@empresa", model.EmpresaId));
						command.Parameters.Add(new SqlParameter("@user", model.UserCad));

						command.ExecuteNonQuery();
					}
				}

				output = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}

		public string DesativaCliente(int id, string user)
		{
			string output = string.Empty;

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand("spr_DELETE_CLEINTE", connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(new SqlParameter("@id", id));
						command.Parameters.Add(new SqlParameter("@user", user));

						int retorno = command.ExecuteNonQuery();

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
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}

		public DataTable GetClientes(int? id)
		{
			DataTable output = new DataTable();

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand("spr_GET_CLIENTES", connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(new SqlParameter("@id", id));

						using (SqlDataReader reader = command.ExecuteReader())
						{
							output.Load(reader);
						}
					}
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}

		public DataTable GetEquipamentos(int clienteId)
		{
			DataTable output = new DataTable();

			try
			{
				using (SqlConnection conn = new SqlConnection(_connectionString))
				{
					conn.Open();

					using (SqlCommand command = new SqlCommand("spr_GET_EQUIPAMENTO_CLIENTE", conn))
					{
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(new SqlParameter("@cliente", clienteId));

						using (SqlDataReader reader = command.ExecuteReader())
						{
							output.Load(reader);
						}
					}
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}

		public async Task<string> GetHashLogin(string login)
		{
			string output = string.Empty;

			try
			{
				var query = $"SELECT SENHA FROM TB_USERS WHERE EMAIL = '{login}'";

				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						output = command.ExecuteScalar()?.ToString();
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}

		public async Task<DataTable> GetUserProfile(string login)
		{
			DataTable dt = new DataTable();

			try
			{
				var query = $"SELECT EMAIL, COD_EMPRESA, NOME_EMPRESA, PERFIL FROM TB_USERS WHERE EMAIL = '{login}'";

				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							dt.Load(reader);
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return dt;
		}

		public string UpdateCliente(ClienteModel model)
		{
			string output = string.Empty;

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand("spr_UPDATE_CLIENTE", connection))
					{
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.Add(new SqlParameter("@id", model.ID));
						command.Parameters.Add(new SqlParameter("@nome", model.Nome));
						command.Parameters.Add(new SqlParameter("@documento", model.Documento));
						command.Parameters.Add(new SqlParameter("@email", model.Email));
						command.Parameters.Add(new SqlParameter("@telefone", model.Telefone));
						command.Parameters.Add(new SqlParameter("@responsavel", model.Responsavel));
						command.Parameters.Add(new SqlParameter("@endereco", model.Endereco));
						command.Parameters.Add(new SqlParameter("@numero", model.Numero));
						command.Parameters.Add(new SqlParameter("@complemento", model.Complemento));
						command.Parameters.Add(new SqlParameter("@bairro", model.Bairro));
						command.Parameters.Add(new SqlParameter("@cidade", model.Cidade));
						command.Parameters.Add(new SqlParameter("@estado", model.Estado));
						command.Parameters.Add(new SqlParameter("@cep", model.Cep));
						command.Parameters.Add(new SqlParameter("@user", model.UserCad));

						int retorno = command.ExecuteNonQuery();

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
