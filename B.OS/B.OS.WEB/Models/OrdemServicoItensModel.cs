namespace B.OS.WEB.Models
{
	public class OrdemServicoItensModel
	{
		public int Codigo { get; set; }
		public int OsCodigo { get; set; }
		public string ProdutoServico { get; set; }
		public double ValorUnitario { get; set; }
		public int Quantidade { get; set; }
		public double ValorTotal { get; set; }
		public DateTime DtCadastro { get; set; }
	}
}
