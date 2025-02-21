using PMOC360.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Domain.Interfaces
{
	public interface IPmocModeloRepository : IRepository<PmocModeloModel>
	{
		DataTable ImportarListaPmocModelo(int id);
		DataTable ImportarPmocModelo(int id);
	}
}
