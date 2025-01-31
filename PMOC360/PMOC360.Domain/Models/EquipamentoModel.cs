using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Domain.Models
{
	public class EquipamentoModel : ParametrosExecucaoModel
	{
		public int? ID { get; set; }

		public string ClienteID { get; set; }

		public string Equipamento { get; set; }

		public string Fabricante { get; set; }

		public string Modelo { get; set; }

		public string Potencia { get; set; }

		public string Serie { get; set; }

		public string Tag { get; set; }

		public string TipoAtividade { get; set; }

		public string Ambiente { get; set; }

		public int Fixos { get; set; }

		public int Flutuantes { get; set; }

		public int PmocModeloID { get; set; }

		public string barCode { get; set; }

		public int? Ativo { get; set; }

		public int EmpresaId { get; set; }
	}
}
