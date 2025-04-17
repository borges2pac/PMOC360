using Dapper;
using PMOC360.Web.Models.Data;
using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Repository.Interfaces;
using System.Data;

namespace PMOC360.Web.Models.Repository
{
	public class PmocModeloItensRepository : IPmocModeloItensRepository
	{
		private readonly IDapperRepository _dapper;

		public PmocModeloItensRepository(IDapperRepository dapper)
		{
			_dapper = dapper;
		}

		public ModeloItensModel ImportarListaItensPorId(int id, int empresaId)
		{
			try
			{
				var sprParams = new DynamicParameters();

				sprParams.Add("@id", id, DbType.Int32);
				sprParams.Add("@empresaId", empresaId, DbType.Int32);

				return _dapper.execute_sp<ModeloItensModel>($"spr_GET_ITENS_POR_ID", sprParams, commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ModeloItensModel> ImportarListaItensPorModelo(int modeloId, int empresaId)
		{
			try
			{
				var sprParams = new DynamicParameters();

				sprParams.Add("@modeloId", modeloId, DbType.Int32);
				sprParams.Add("@empresaId", empresaId, DbType.Int32);

				return _dapper.GetAll<ModeloItensModel>($"spr_GET_ITENS_POR_MODELO", sprParams, commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
