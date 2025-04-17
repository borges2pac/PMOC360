using Dapper;
using Microsoft.Data.SqlClient;
using PMOC360.Web.Models.Data;
using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace PMOC360.Web.Models.Repository
{
	public class TecnicoRepository : ITecnicoRepository
	{
		private readonly IDapperRepository _dapper;

		public TecnicoRepository(IDapperRepository dapper)
		{
			_dapper = dapper;
		}

		public bool CadastrarTecnico(TecnicoModel model)
		{
			bool output = false;

			try
			{
				var sprParams = new DynamicParameters();

				sprParams.Add("@nome", model.Nome, DbType.String);
				sprParams.Add("@email", model.Email, DbType.String);
				sprParams.Add("@cpf", model.Cpf, DbType.String);
				sprParams.Add("@telefone", model.Telefone, DbType.String);
				sprParams.Add("@empresa", model.Cod_empresa, DbType.Int32);
				sprParams.Add("@user", model.User_Cad, DbType.String);

				_dapper.execute_sp<int?>($"spr_CADASTRAR_TECNICO", sprParams, commandType: CommandType.StoredProcedure);

				output = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}

		public List<TecnicoModel> GetTecnicos(int empresaId)
		{
			try
			{
				var sprParams = new DynamicParameters();

				sprParams.Add("@empresaId", empresaId, DbType.Int32);

				return _dapper.GetAll<TecnicoModel>($"spr_GET_TECNICOS_LIST", sprParams, commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
