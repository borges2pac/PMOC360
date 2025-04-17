using PMOC360.Web.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Web.Models.Repository.Interfaces
{
	public interface ITecnicoRepository
	{
		bool CadastrarTecnico(TecnicoModel model);
		List<TecnicoModel> GetTecnicos(int empresaId);
	}
}
