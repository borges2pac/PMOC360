using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Web.Models.Models
{
	public class TecnicoModel : ParametrosExecucaoModel
	{
		public int? ID { get; set; }

		public string Nome { get; set; }

		public string Email { get; set; }

		public string Cpf { get; set; }

		public string Telefone { get; set; }

		public int? Ativo { get; set; }

		public int Cod_empresa { get; set; }
	}
}
