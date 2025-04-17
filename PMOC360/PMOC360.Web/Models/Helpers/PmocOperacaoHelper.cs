namespace PMOC360.Web.Models.Helpers
{
	public class PmocOperacaoHelper
	{
		public PmocOperacaoHelper()
		{
				
		}

		public DateTime ObterDataManutencao(string frequencia, DateTime dataVisita)
		{
			DateTime output = new DateTime().Date;
			try
			{
				switch (frequencia) 
				{
					case "Semanal":
						output = dataVisita.AddDays(7);
						break;
					case "Mensal":
						output = dataVisita.AddMonths(1);
						break;
					case "Bimestral":
						output = dataVisita.AddMonths(2);
						break;
					case "Trimestral":
						output = dataVisita.AddMonths(3);
						break;
					case "Semestral":
						output = dataVisita.AddMonths(6);
						break;
					case "Anual":
						output = dataVisita.AddYears(1);
						break;
					default:
						throw new Exception("Erro ao gerar a data da próxima visita. Contate o suporte.");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}
	}
}
