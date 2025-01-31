using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Domain.Models
{
	public class TecnicoModel : ParametrosExecucaoModel
	{
		public int? ID { get; set; }

		public string Nome { get; set; }

		public string Email { get; set; }

		public string Documento { get; set; }

		public string Telefone { get; set; }

		public int? Ativo { get; set; }

		public int EmpresaId { get; set; }
	}
}
