using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Domain.Models
{
	public class PmocPlanoModel : ParametrosExecucaoModel
	{
		public int? ID { get; set; }

		public string Nome { get; set; }

		public int ClienteID { get; set; }

		public int Tecnico1ID { get; set; }

		public int Tecnico2ID { get; set; }

		public int Tecnico3ID { get; set; }

		public string Engenheiro { get; set; }

		public string Registro { get; set; }

		public DateTime PeriodoInicial { get; set; }

		public DateTime PeriodoFinal { get; set; }

		public int EmpresaId { get; set; }
	}
}
