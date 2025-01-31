using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Data
{
	public interface ISqlExecutor
	{
		DataTable GetClientes(int? id);
	}
}
