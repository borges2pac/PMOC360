using Dapper;
using PMOC360.Web.Models.Data;
using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Repository.Interfaces;
using System.Data;

namespace PMOC360.Web.Models.Repository
{
	public class PmocModeloRepository : IPmocModeloRepository
	{
		private readonly IDapperRepository _dapper;

		public PmocModeloRepository(IDapperRepository dapper)
		{
			_dapper = dapper;
		}

		public List<PmocModeloModel> ImportarListaPmocModelo(int empresaId)
		{
			try
			{
				var sprParams = new DynamicParameters();

				sprParams.Add("@empresaId", empresaId, DbType.Int32);

				return _dapper.GetAll<PmocModeloModel>($"spr_GET_MODELO_LIST", sprParams, commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<PmocModeloModel> ImportarPmocModelo(int id, int empresaId)
		{
			try
			{
				var sprParams = new DynamicParameters();

				sprParams.Add("@id", id, DbType.Int32);
				sprParams.Add("@empresaId", empresaId, DbType.Int32);

				return await _dapper.GetChange<PmocModeloModel>($"spr_GET_MODELO", sprParams, commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
