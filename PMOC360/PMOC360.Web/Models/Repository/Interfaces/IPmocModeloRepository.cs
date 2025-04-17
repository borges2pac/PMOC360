using PMOC360.Web.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Web.Models.Repository.Interfaces
{
	public interface IPmocModeloRepository
	{
		List<PmocModeloModel> ImportarListaPmocModelo(int empresaId);
		//PmocModeloModel ImportarPmocModelo(int id, int empresaId);

		Task<PmocModeloModel> ImportarPmocModelo(int id, int empresaId);
	}
}
