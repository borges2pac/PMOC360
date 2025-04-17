using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Services;
using PMOC360.Web.Models.ViewModels;

namespace PMOC360.Web.Models.Services
{
	public interface IEquipamentoService : IService<EquipamentoModel>
	{
		IEnumerable<EquipamentoViewModel> GetAllId(int id, int empresaId);

		EquipamentoViewModel GetEquipamentoByCode(int barCode);
	}
}
