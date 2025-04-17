using System.ComponentModel.DataAnnotations;

namespace B.OS.WEB.Models
{
	public class TabOrdemServico : BaseEntity
	{
		[Key]
		public int Codigo { get; set; }
		public int ClienteId{ get; set; }
		public DateTime Abertura { get; set; }
		public string Equipamento { get; set; }
		public string Fabricante { get; set; }
		public string Modelo { get; set; }
		public string Problema { get; set; }
		public string Diagnostico { get; set; }
		public string Solucao { get; set; }
		public string Observacao { get; set; }
		public DateTime? Fechamento { get; set; }
		public string Status { get; set; }		
	}
}
