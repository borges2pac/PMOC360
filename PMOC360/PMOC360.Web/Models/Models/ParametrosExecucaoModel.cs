using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Web.Models.Models
{
	public class ParametrosExecucaoModel
	{
		public string User_Cad { get; set; }

		public string User_Alt { get; set; }

		public DateTime? Data_Cad { get; set; }

		public DateTime? Data_Alt { get; set; }
	}
}
