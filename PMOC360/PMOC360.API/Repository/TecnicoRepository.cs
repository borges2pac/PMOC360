using PMOC360.Data;
using PMOC360.Domain.Interfaces;
using PMOC360.Domain.Models;
using System.Collections.Generic;
using System.Data;

namespace PMOC360.API.Repository
{
	public class TecnicoRepository : ITecnicoRepository
	{
		private readonly ISqlExecutor _sqlExecutor;

		public TecnicoRepository(ISqlExecutor sqlExecutor)
		{
			_sqlExecutor = sqlExecutor;
		}

		public string Alterar(TecnicoModel model)
		{
			throw new NotImplementedException();
		}

		public string Excluir(int id, string user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TecnicoModel> GetAll()
		{
			List<TecnicoModel> tecnicos = new List<TecnicoModel>();

			try
			{
				var list = _sqlExecutor.GetTecnicos();

				if(list != null)
				{
					foreach(DataRow dr in list.Rows) 
					{
						var model = new TecnicoModel() 
						{
							ID = Convert.ToInt32(dr["ID"].ToString()),
							Nome = dr["NOME"].ToString(),
							Email = dr["EMAIL"].ToString(),
							Documento = dr["CPF"].ToString(),
							Telefone = dr["TELEFONE"].ToString(),
							Ativo = Convert.ToInt32(dr["ATIVO"].ToString()),
							EmpresaId = Convert.ToInt32(dr["COD_EMPRESA"].ToString())
						};

						tecnicos.Add(model);
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return tecnicos;
		}

		public TecnicoModel GetForId(int id)
		{
			throw new NotImplementedException();
		}

		public string Incluir(TecnicoModel model)
		{
			try
			{
				var retorno =  _sqlExecutor.CadastrarTecnico(model);

				if (retorno)
					return "Cadastrado com Sucesso!";
				else
					throw new Exception("Erro ao cadastrar o tecnico, favor entrar em contato com o suporte.");
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
