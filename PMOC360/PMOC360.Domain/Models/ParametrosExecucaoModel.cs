using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Domain.Models
{
	public class ParametrosExecucaoModel
	{
		public string UserCad { get; set; }

		public string UserAlt { get; set; }

		public DateTime? DataCad { get; set; }

		public DateTime? DataAlt { get; set; }
	}
}
