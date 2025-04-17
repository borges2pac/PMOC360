using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Repository.Interfaces;
using PMOC360.Web.Models.ViewModels;
using System.Data;

namespace PMOC360.Web.Models.Services
{
	public class EquipamentoService : IEquipamentoService
	{
		private readonly IEquipamentoRepository _repository;

		public EquipamentoService(IEquipamentoRepository repository)
		{
			_repository = repository;
		}

		public string Alterar(EquipamentoModel model)
		{
			throw new NotImplementedException();
		}

		public string Excluir(int id, int empresaId, string user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<EquipamentoModel> GetAll(int empresaId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<EquipamentoModel> GetAllForId(int id, int empresaId)
		{
			throw new NotImplementedException();
		}

		public EquipamentoModel GetForId(int id, int empresaId)
		{
			throw new NotImplementedException();
		}

		public string Incluir(EquipamentoModel model)
		{
			string output = string.Empty;

			try
			{
				var retornoExecução = _repository.CadastrarEquipamentos(model);

				if (retornoExecução)
					output = "Equipamento cadastrado com sucesso!";
				else
					output = "Falha ao cadastrar o equipamento.";
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}

		public IEnumerable<EquipamentoViewModel> GetAllId(int id, int empresaId)
		{
			List<EquipamentoViewModel> lista = new List<EquipamentoViewModel>();
			EquipamentoViewModel model = new EquipamentoViewModel();

			try
			{
				var retorno = _repository.GetEquipamentos(id, empresaId);

				if (retorno.Count > 0)
				{
					foreach (var item in retorno)
					{
						model.ID = item.ID;
						model.ClienteID = item.Cliente_ID;
						model.Equipamento = item.Equipamento;
						model.Fabricante = item.Fabricante;
						model.Modelo = item.Modelo;
						model.Potencia = item.Potencia;
						model.Serie = item.Serie;
						model.Tag = item.Tag;
						model.TipoAtividade = item.Tipo_Atividade;
						model.Ambiente = item.Ambiente;
						model.Fixos = item.Fixos;
						model.Flutuantes = item.Flutuantes;
						model.PmocModeloID = item.Pmoc_Modelo_ID;
						model.barCode = item.Cod_Etiqueta;
						model.Ativo = item.Ativo == null ? 0 : (int)item.Ativo;
						model.EmpresaId = item.Cod_Empresa;
						model.UserAlt = item.User_Alt;
						model.UserCad = item.User_Cad;
						model.DataAlt = item.Data_Alt == null ? new DateTime() : (DateTime)item.Data_Alt;
						model.DataCad = item.Data_Cad == null ? new DateTime() : (DateTime)item.Data_Cad;

						lista.Add(model);
						model = new EquipamentoViewModel();
					}
				}
				else
				{
					lista = new List<EquipamentoViewModel>();
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}

			return lista;
		}

		public EquipamentoViewModel GetEquipamentoByCode(int barCode)
		{
			EquipamentoViewModel model = new EquipamentoViewModel();

			try
			{
				var retorno = _repository.GetEquipamentoByCode(barCode);

				if (retorno != null)
				{
					model.ID = retorno.ID;
					model.ClienteID = retorno.Cliente_ID;
					model.Equipamento = retorno.Equipamento;
					model.Fabricante = retorno.Fabricante;
					model.Modelo = retorno.Modelo;
					model.Potencia = retorno.Potencia;
					model.Serie = retorno.Serie;
					model.Tag = retorno.Tag;
					model.TipoAtividade = retorno.Tipo_Atividade;
					model.Ambiente = retorno.Ambiente;
					model.Fixos = retorno.Fixos;
					model.Flutuantes = retorno.Flutuantes;
					model.PmocModeloID = retorno.Pmoc_Modelo_ID;
					model.barCode = retorno.Cod_Etiqueta;
					model.Ativo = retorno.Ativo == null ? 0 : (int)retorno.Ativo;
					model.EmpresaId = retorno.Cod_Empresa;
					model.UserAlt = retorno.User_Alt;
					model.UserCad = retorno.User_Cad;
					model.DataAlt = retorno.Data_Alt == null ? new DateTime() : (DateTime)retorno.Data_Alt;
					model.DataCad = retorno.Data_Cad == null ? new DateTime() : (DateTime)retorno.Data_Cad;
				}
				else
				{
					model = new EquipamentoViewModel();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return model;
		}
	}
}
