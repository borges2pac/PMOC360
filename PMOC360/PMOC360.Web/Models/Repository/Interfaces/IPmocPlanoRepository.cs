using PMOC360.Web.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Web.Models.Repository.Interfaces
{
	public interface IPmocPlanoRepository
	{
		List<PmocPlanoModel> GetAllPmocPlano(int empresaId);
		Task<PmocPlanoModel> GetPmocPlanoForId(int id, int empresaId);
	}
}
