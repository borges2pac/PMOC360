using PMOC360.Data;
using PMOC360.Domain.Interfaces;
using PMOC360.Domain.Models;
using System.Data;

namespace PMOC360.API.Repository
{
	public class EquipamentoRepository : IEquipamentoRepository
	{
		private readonly ISqlExecutor _sqlExecutor;

		public EquipamentoRepository(ISqlExecutor sqlExecutor)
		{
			_sqlExecutor = sqlExecutor;
		}

		public string Alterar(EquipamentoModel model)
		{
			throw new NotImplementedException();
		}

		public string Excluir(int id, string user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<EquipamentoModel> GetAll()
		{
			throw new NotImplementedException();
		}

		public DataTable GetEquipamentos(int clienteId)
		{
			try
			{
				return _sqlExecutor.GetEquipamentos(clienteId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public EquipamentoModel GetForId(int id)
		{
			throw new NotImplementedException();
		}

		public string Incluir(EquipamentoModel model)
		{
			try
			{
				var retonro = _sqlExecutor.CadastrarEquipamentos(model);

				if (retonro)
					return "Cadastrado com Sucesso!";
				else
					throw new Exception("Erro ao cadastrar o equipamento, favor entrar em contato com o suporte.");
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
