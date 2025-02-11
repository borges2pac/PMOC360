using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Data
{
	public class Config
	{
		private readonly IConfiguration _configuration;
		public static IConfiguration Configuration;

		public Config(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public static string getConn(string acesso)
		{
			var connectionString = Configuration.GetConnectionString(acesso);

			return connectionString;
		}
		
		public static string getUrlApiPmoc(string url)
		{
			var urlApi = Configuration.GetConnectionString(url);

			return urlApi;
		}
	}
}
