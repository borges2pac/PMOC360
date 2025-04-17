using Dapper;
using System.Data;

namespace PMOC360.Web.Models.Data
{
	public interface IDapperRepository
	{
		T execute_sp<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure);
		List<T> GetAll<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure);
		List<T> GetAllChange<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure);
		Task<T> GetChange<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure);
	}
}
