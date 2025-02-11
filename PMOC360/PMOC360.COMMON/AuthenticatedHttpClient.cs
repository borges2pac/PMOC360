using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.COMMON
{
	public class AuthenticatedHttpClient : HttpClient
	{
		public AuthenticatedHttpClient() 
		{
			var username = "";
			var password = "";

			var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(username + ":" + password));
			DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authString);
		}
	}
}
