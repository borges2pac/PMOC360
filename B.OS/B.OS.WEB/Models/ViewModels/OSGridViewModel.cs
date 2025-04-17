namespace B.OS.WEB.Models.ViewModels
{
	public class OSGridViewModel : BaseEntity
	{
		public int Codigo { get; set; }
		public string Cliente { get; set; }
		public DateTime Abertura { get; set; }
		public string Equipamento { get; set; }		
		public string Status { get; set; }
	}
}
