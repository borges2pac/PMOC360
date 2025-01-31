using PMOC360.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Domain.Interfaces
{
	public interface IRepository<T>
	{
		string Incluir(T model);		
		string Alterar(T model);
		string Excluir(int id, string user);
		T GetForId(int id);
		IEnumerable<T> GetAll();
	}
}
