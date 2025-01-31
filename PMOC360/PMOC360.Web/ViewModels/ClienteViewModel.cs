namespace PMOC360.Web.ViewModels
{
	public class ClienteViewModel
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

		public int? EmpresaId { get; set; }

		public string UserCad { get; set; }

		public string UserAlt { get; set; }

		public DateTime DataCad { get; set; }

		public DateTime DataAlt { get; set; }
	}
}
