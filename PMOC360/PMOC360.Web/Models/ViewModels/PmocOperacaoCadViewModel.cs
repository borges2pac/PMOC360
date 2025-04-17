namespace PMOC360.Web.Models.ViewModels
{
	public class PmocOperacaoCadViewModel
	{
		public int Cod_Empresa { get; set; }

		public int Cliente_Id { get; set; }

		public int Equipamento_Id { get; set; }

		public int Modelo_Id { get; set; }

		public List<ItemViewModel> Itens { get; set; }

		public DateTime Dt_Ultima_Visita { get; set; } = DateTime.Now.Date;

		public string UserCad { get; set; }

		public ArquivosImgViewModel Imagens { get; set; }

		public byte[]? ImagemDadosOne { get; set; }
	}
}
