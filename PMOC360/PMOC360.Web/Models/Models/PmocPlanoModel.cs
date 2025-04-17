using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Web.Models.Models
{
	public class PmocPlanoModel : ParametrosExecucaoModel
	{
		public int? ID { get; set; }

		public string Nome { get; set; }

		public int Id_Cliente { get; set; }

		public int Id_Tecnico1 { get; set; }

		public int? Id_Tecnico2 { get; set; }

		public int? Id_Tecnico3 { get; set; }

		public string Engenheiro { get; set; }

		public string Registro { get; set; }

		public DateTime Periodo_Ini { get; set; }

		public DateTime Periodo_Fim { get; set; }

		public int? Ativo { get; set; }

		public int Cod_Empresa { get; set; }
	}
}
