using Microsoft.Extensions.Configuration;
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
	}
}
