using System.ComponentModel.DataAnnotations;

namespace B.OS.WEB.Models
{
	public class TabFaturaItens : BaseEntity
	{
		[Key]
		public int Codigo { get; set; }

		public int FaturaId { get; set; }

		public DateTime Data { get; set; }

		public int CodigoItem { get; set; }

		public string Produto { get; set; }

		public decimal VlUnitario { get; set; }

		public int Quantidade { get; set; }

		public decimal VlTotal { get; set; }
	}
}
