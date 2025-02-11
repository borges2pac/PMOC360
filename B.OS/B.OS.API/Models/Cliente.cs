using System.ComponentModel.DataAnnotations;

namespace B.OS.API.Models
{
	public class Cliente
	{
		public int Id { get; set; }

		public string Tipo { get; set; }

		public string Nome { get; set; }

		public string Documento { get; set; }

		public string Email { get; set; }

		public string Telefone { get; set; }

		public string Endereco { get; set; }

		public string Cidade { get; set; }

		public string Estado { get; set; }

		public string Cep { get; set; }

		public string Contato { get; set; }

		public DateTime DataCadastro { get; set; }
	}
}
