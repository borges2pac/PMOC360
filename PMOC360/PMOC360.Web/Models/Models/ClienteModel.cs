using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Web.Models.Models
{
	public class ClienteModel : ParametrosExecucaoModel
	{
		public int? ID { get; set; }

		public string Nome { get; set; }

		public string Documento { get; set; }

		public string Email { get; set; }

		public string Telefone { get; set; }

		public string Responsavel { get; set; }

		public string Endereco { get; set; }

		public string Numero { get; set; }

		public string Complemento { get; set; }

		public string Bairro { get; set; }

		public string Cidade { get; set; }

		public string Estado { get; set; }

		public string Cep { get; set; }

		public int? Ativo { get; set; }

		public int Cod_Empresa { get; set; }
	}
}
