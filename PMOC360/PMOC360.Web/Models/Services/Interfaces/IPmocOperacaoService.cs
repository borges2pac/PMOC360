using PMOC360.Web.Models.ViewModels;

namespace PMOC360.Web.Models.Services.Interfaces
{
	public interface IPmocOperacaoService
	{
		PmocOperacaoViewModel GetDadosOperacao(string barCode);

		bool InsertOperacao(PmocOperacaoCadViewModel model);
	}
}
