using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Web.Models.Services
{
	public interface IService<T>
	{
		string Incluir(T model);
		string Alterar(T model);
		string Excluir(int id, int empresaId, string user);
		T GetForId(int id, int empresaId);
		IEnumerable<T> GetAll(int empresaId);
		IEnumerable<T> GetAllForId(int id, int empresaId);
	}
}
