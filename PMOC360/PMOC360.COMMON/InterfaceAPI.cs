using Newtonsoft.Json;
using PMOC360.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PMOC360.COMMON
{
	public class InterfaceAPI
	{
		public static async Task<HttpResponseMessage> ExecutaApiGet(ParametrosApiModel parametros)
		{
			try
			{
				//using var client = new AuthenticatedHttpClient();
				using var client = new HttpClient();
				var urlApi = ConfigurationManager.AppSettings["URLAPI"] + parametros.ApiName + "/" + parametros.Rota;
				var response = await client.GetAsync(urlApi);

				if (response.StatusCode == System.Net.HttpStatusCode.OK)
					return response;
				else
					throw new Exception(response.Content.ReadAsStringAsync().Result);
			}	
			catch (Exception)
			{
				throw;
			}
		}

		public static async Task<HttpResponseMessage> ExecutaApiPost(ParametrosApiModel parametros)
		{
			try
			{
				string objEnvio = JsonConvert.SerializeObject(parametros.Parametros);
				StringContent content = new StringContent(objEnvio, Encoding.UTF8, "application/json");

				//using var client = new AuthenticatedHttpClient();
				using var client = new HttpClient();
				var urlApi = ConfigurationManager.AppSettings["URLAPI"] + parametros.ApiName + "/" + parametros.Rota;
				var response = await client.PostAsync(urlApi, content);

				if (response.StatusCode == System.Net.HttpStatusCode.OK)
					return response;
				else
					throw new Exception(response.Content.ReadAsStringAsync().Result);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
