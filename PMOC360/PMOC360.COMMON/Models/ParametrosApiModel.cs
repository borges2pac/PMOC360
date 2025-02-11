using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.COMMON.Models
{
	public class ParametrosApiModel
	{
		public string ApiName { get; set; }

		public string Rota { get; set; }

		public dynamic? Parametros { get; set; }
	}
}
