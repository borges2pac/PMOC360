using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Web.Models.Services
{
	public interface IClienteService : IService<ClienteModel>
	{
		public IEnumerable<ClienteViewModel> GetAll(int empresaId);
	}
}
