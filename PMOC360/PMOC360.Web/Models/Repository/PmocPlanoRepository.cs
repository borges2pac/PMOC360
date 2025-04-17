using Dapper;
using PMOC360.Web.Models.Data;
using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Repository.Interfaces;
using System.Data;

namespace PMOC360.Web.Models.Repository
{
	public class PmocPlanoRepository : IPmocPlanoRepository
	{
		private readonly IDapperRepository _dapper;

		public PmocPlanoRepository(IDapperRepository dapper)
		{
			_dapper = dapper;
		}

		public List<PmocPlanoModel> GetAllPmocPlano(int empresaId)
		{
			try
			{
				var sprParams = new DynamicParameters();

				sprParams.Add("@empresaId", empresaId, DbType.Int32);

				return _dapper.GetAll<PmocPlanoModel>($"spr_GET_PMOC_PLANO", sprParams, commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<PmocPlanoModel> GetPmocPlanoForId(int id, int empresaId)
		{
			try
			{
				var sprParams = new DynamicParameters();

				sprParams.Add("@id", id, DbType.Int32);
				sprParams.Add("@empresaId", empresaId, DbType.Int32);

				return await _dapper.GetChange<PmocPlanoModel>($"spr_GET_PMOC_PLANO_ID", sprParams, commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
