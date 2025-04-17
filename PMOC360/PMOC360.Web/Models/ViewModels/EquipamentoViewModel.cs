namespace PMOC360.Web.Models.ViewModels
{
	public class EquipamentoViewModel
	{
		public int? ID { get; set; }

		public int ClienteID { get; set; }

		public string Equipamento { get; set; }

		public string Fabricante { get; set; }

		public string Modelo { get; set; }

		public string Potencia { get; set; }

		public string Serie { get; set; }

		public string Tag { get; set; }

		public string TipoAtividade { get; set; }

		public string Ambiente { get; set; }

		public int Fixos { get; set; }

		public int Flutuantes { get; set; }

		public int PmocModeloID { get; set; }

		public string barCode { get; set; }

		public int? Ativo { get; set; }

		public int? EmpresaId { get; set; }

		public string UserCad { get; set; }

		public string UserAlt { get; set; }

		public DateTime DataCad { get; set; }

		public DateTime DataAlt { get; set; }
	}
}
