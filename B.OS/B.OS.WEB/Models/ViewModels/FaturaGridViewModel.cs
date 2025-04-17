namespace B.OS.WEB.Models.ViewModels
{
	public class FaturaGridViewModel : BaseEntity
	{
		public int Codigo { get; set; }

		public string Cliente { get; set; }

		public DateTime Data { get; set; }

		public decimal Total { get; set; }

		public string Pago { get; set; }
	}
}
