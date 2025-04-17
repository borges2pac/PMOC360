using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Web.Models.Models
{
	public class ModeloItensModel : ParametrosExecucaoModel
	{
		public int? ID { get; set; }

		public int ModeloID { get; set; }

		public string Descricao { get; set; }

		public string Frequencia { get; set; }

		public string Observacao { get; set; }

		public int Cod_Empresa { get; set; }
	}
}
