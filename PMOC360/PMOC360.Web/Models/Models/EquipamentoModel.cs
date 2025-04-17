using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Web.Models.Models
{
	public class EquipamentoModel : ParametrosExecucaoModel
	{
		public int? ID { get; set; }

		public int Cliente_ID { get; set; }

		public string Equipamento { get; set; }

		public string Fabricante { get; set; }

		public string Modelo { get; set; }

		public string Potencia { get; set; }

		public string Serie { get; set; }

		public string Tag { get; set; }

		public string Tipo_Atividade { get; set; }

		public string Ambiente { get; set; }

		public int Fixos { get; set; }

		public int Flutuantes { get; set; }

		public int Pmoc_Modelo_ID { get; set; }

		public string Cod_Etiqueta { get; set; }

		public int? Ativo { get; set; }

		public int Cod_Empresa { get; set; }
	}
}
