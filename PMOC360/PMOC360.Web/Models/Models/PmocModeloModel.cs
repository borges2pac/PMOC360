using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Web.Models.Models
{
	public class PmocModeloModel : ParametrosExecucaoModel
	{
		public int? ID { get; set; }

		public string Nome { get; set; }

		public int Cod_Empresa { get; set; }
	}
}
