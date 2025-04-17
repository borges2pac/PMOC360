using System.ComponentModel.DataAnnotations;

namespace B.OS.WEB.Models
{
	public class TabFatura : BaseEntity
	{
		[Key]
		public int Codigo { get; set; }

		public int ClienteId { get; set; }

		public DateTime Data { get; set; }

		public int QtdItens { get; set; }

		public decimal Subtotal { get; set; }

		public decimal Descontos { get; set; }

		public decimal Total { get; set; }

		public string Garantia { get; set; }

		public DateTime? GarantiaAte { get; set; }

		public string PagamentoTipo { get; set; }

		public int PrazoPagamento { get; set; }

		public DateTime DataPagamento { get; set; }

		public string Pago { get; set; }
	}
}
