using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PMOC360.Web.Models.Data
{
	public class DapperRepository : IDapperRepository
	{
		private readonly IConfiguration _configuration;

		public DapperRepository(IConfiguration configuration)
		{
			_configuration = configuration;	
		}

		public T execute_sp<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure)
		{
			try
			{
				T result;

				using (IDbConnection dbConnection = new SqlConnection(Config.getConn))
				{
					if(dbConnection.State == ConnectionState.Closed)
						dbConnection.Open();

					var transaction = dbConnection.BeginTransaction();

					try
					{
						dbConnection.Query<T>(query, sp_params, commandType: commandType, transaction: transaction);

						result = sp_params.Get<T>("retVal");

						transaction.Commit();
					}
					catch (Exception ex) 
					{
						transaction.Rollback();
						throw ex;
					}
				};

				return result;
			}
			catch (Exception ex) 
			{
				throw ex;
			}
		}

		public List<T> GetAll<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure)
		{
			try
			{
				IDbConnection dbConnection = new SqlConnection(Config.getConn);
				return dbConnection.Query<T>(query, sp_params, commandType: commandType).ToList();
			}
			catch (Exception ex) 
			{
				throw ex;
			}
		}

		public List<T> GetAllChange<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure)
		{
			try
			{
				IDbConnection dbConnection = new SqlConnection(Config.getConn);
				return dbConnection.Query<T>(query, sp_params, commandType: commandType).ToList();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<T> GetChange<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure)
		{
			try
			{
				IDbConnection dbConnection = new SqlConnection(Config.getConn);
				return await dbConnection.QuerySingleOrDefaultAsync<T>(query, sp_params, commandType: commandType);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
