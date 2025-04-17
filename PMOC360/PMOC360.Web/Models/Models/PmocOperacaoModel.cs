namespace PMOC360.Web.Models.Models
{
	public class PmocOperacaoModel : ParametrosExecucaoModel
	{
		public int? Id { get; set; }

		public int Cod_Empresa { get; set; }

		public int Cliente_Id { get; set; }

		public int Equipamento_Id { get; set; }

		public int Modelo_Id { get; set; }

		public int Modelo_Item_Id { get; set; }

		public DateTime Dt_Ultima_Visita { get; set; }

		public DateTime Dt_Proxima_Visita { get; set; }		
	}
}
