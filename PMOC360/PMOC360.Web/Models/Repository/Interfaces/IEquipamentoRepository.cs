using PMOC360.Web.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Web.Models.Repository.Interfaces
{
	public interface IEquipamentoRepository 
	{
		bool CadastrarEquipamentos(EquipamentoModel model);

		List<EquipamentoModel> GetEquipamentos(int clienteId, int empresaId);

		EquipamentoModel GetEquipamentoByCode(int barCode);
	}
}
