using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Service.Interfaces
{
	public interface IService<T>
	{
		string Incluir(T model);
		string Alterar(T model);
		string Excluir(int id, string user);
		T GetForId(int id);
		IEnumerable<T> GetAll();
	}
}
