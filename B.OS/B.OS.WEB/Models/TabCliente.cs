using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace B.OS.WEB.Models
{
	public class TabCliente : BaseEntity
	{
		[Key]
		public int Codigo { get; set; }

		public string Tipo { get; set; }

		public string Nome { get; set; }
		
		public string Documento { get; set; }
		
		public string? Contato { get; set; }
		
		public string? Endereco { get; set; }

		public string? CEP { get; set; }

		public string? Cidade { get; set; }

		public string? Estado { get; set; }

		public string? Telefone { get; set; }

		public string WhatsApp { get; set; }

		public string Email { get; set; }

		public DateTime DataCadastro { get; set; }
	}
}
