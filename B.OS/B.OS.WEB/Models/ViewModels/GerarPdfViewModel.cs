namespace B.OS.WEB.Models.ViewModels
{
	public class GerarPdfViewModel
	{
		public int Codigo { get; set; }
		public DateTime Abertura { get; set; }
		public int ClienteId { get; set; }
		public string ClienteNome { get; set; }
		public string Documento { get; set; }
		public string Endereco { get; set; }
		public string Telefone { get; set; }
		public string Equipamento { get; set; }
		public string Fabricante { get; set; }
		public string Modelo { get; set; }
		public string Problema { get; set; }
		public string Observacao { get; set; }
	}
}
