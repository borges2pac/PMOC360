using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMOC360.Domain.Models;
using PMOC360.Domain.Interfaces;
using PMOC360.Data;
using System.Data;

namespace PMOC360.Repository
{
	public class ClienteRepository : IClienteRepository
	{
		private readonly ISqlExecutor _sqlExecutor;

		public ClienteRepository(ISqlExecutor sqlExecutor)
		{
			_sqlExecutor = sqlExecutor;
		}

		public string Alterar(ClienteModel model)
		{
			try
			{
				return string.Empty;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string Excluir(int id, string user)
		{
			try
			{
				return string.Empty;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public IEnumerable<ClienteModel> GetAll()
		{
			List<ClienteModel> list = new List<ClienteModel>();
			int? id = null;

			try
			{
				var retorno = _sqlExecutor.GetClientes(id);

				foreach (DataRow dr in retorno.Rows) 
				{
					var model = new ClienteModel
					{
						ID = Convert.ToInt32(dr["ID"]),
						Nome = Convert.ToString(dr["NOME"]),
						Documento = Convert.ToString(dr["DOCUMENTO"]),
						Email = Convert.ToString(dr["EMAIL"]),
						Telefone = Convert.ToString(dr["TELEFONE"]),
						Responsavel = Convert.ToString(dr["RESPONSAVEL"]),
						Endereco = Convert.ToString(dr["ENDERECO"]),
						Numero = Convert.ToString(dr["NUMERO"]),
						Complemento = Convert.ToString(dr["COMPLEMENTO"]),
						Bairro = Convert.ToString(dr["BAIRRO"]),
						Cidade = Convert.ToString(dr["CIDADE"]),
						Estado = Convert.ToString(dr["ESTADO"]),
						Cep = Convert.ToString(dr["CEP"]),
						Ativo = Convert.ToBoolean(dr["ATIVO"]) == true ? 1 : 0,
						EmpresaId = Convert.ToInt32(dr["COD_EMPRESA"]),
						UserAlt = Convert.ToString(dr["USER_ALT"]),
						UserCad = Convert.ToString(dr["USER_CAD"]),
						DataAlt = string.IsNullOrEmpty(Convert.ToString(dr["DATA_ALT"])) ? null : Convert.ToDateTime(dr["DATA_ALT"]),
						DataCad = string.IsNullOrEmpty(Convert.ToString(dr["DATA_CAD"])) ? null : Convert.ToDateTime(dr["DATA_CAD"])
					};

					list.Add(model);
				}

				return list;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ClienteModel GetForId(int id)
		{
			try
			{
				return new ClienteModel();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string Incluir(ClienteModel model)
		{
			try
			{
				return string.Empty;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
