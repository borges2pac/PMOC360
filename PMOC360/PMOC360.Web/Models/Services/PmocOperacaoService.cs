using PMOC360.Web.Models.Helpers;
using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Repository.Interfaces;
using PMOC360.Web.Models.Services.Interfaces;
using PMOC360.Web.Models.ViewModels;

namespace PMOC360.Web.Models.Services
{
	public class PmocOperacaoService : IPmocOperacaoService
	{
		private readonly IClienteRepository _cliente;
		private readonly IEquipamentoRepository _equipamento;
		private readonly IPmocModeloRepository _pmocModelo;
		private readonly IPmocModeloItensRepository _pmocModeloItens;
		private readonly IPmocPlanoRepository _pmocPlano;

		public PmocOperacaoService(IClienteRepository cliente, IEquipamentoRepository equipamento, IPmocModeloRepository pmocModelo, 
								IPmocModeloItensRepository pmocModeloItens, IPmocPlanoRepository pmocPlano)
		{
			_cliente = cliente;
			_equipamento = equipamento;
			_pmocModelo = pmocModelo;
			_pmocModeloItens = pmocModeloItens;
			_pmocPlano = pmocPlano;
		}

		public PmocOperacaoViewModel GetDadosOperacao(string barCode)
		{
			PmocOperacaoViewModel model = new PmocOperacaoViewModel();
			List<ItemViewModel> listItems = new List<ItemViewModel>();
			ClienteModel modelCliente = new ClienteModel();

			try
			{
				var equipamento = _equipamento.GetEquipamentoByCode(Convert.ToInt32(barCode));

				if (equipamento == null)
					throw new Exception("Equipamento não encontrado.");

				model.Equipamento = new EquipamentoViewModel()
				{
					ID = equipamento.ID,
					ClienteID = equipamento.Cliente_ID,
					Equipamento = equipamento.Equipamento,
					Fabricante = equipamento.Fabricante,
					Modelo = equipamento.Modelo,
					Potencia = equipamento.Potencia,
					Serie = equipamento.Serie,
					Tag = equipamento.Tag,
					TipoAtividade = equipamento.Tipo_Atividade,
					Ambiente = equipamento.Ambiente,
					Fixos = equipamento.Fixos,
					Flutuantes = equipamento.Flutuantes,
					PmocModeloID = equipamento.Pmoc_Modelo_ID,
					barCode = equipamento.Cod_Etiqueta,
					Ativo = equipamento.Ativo == null ? 0 : (int)equipamento.Ativo,
					EmpresaId = equipamento.Cod_Empresa,
					UserAlt = equipamento.User_Alt,
					UserCad = equipamento.User_Cad,
					DataAlt = equipamento.Data_Alt == null ? new DateTime() : (DateTime)equipamento.Data_Alt,
					DataCad = equipamento.Data_Cad == null ? new DateTime() : (DateTime)equipamento.Data_Cad
				};

				var cliente = _cliente.GetClientesById(equipamento.Cliente_ID, equipamento.Cod_Empresa);

				if (cliente == null)
					throw new Exception("Cliente vinculado a este equipamento não encontrado.");

				foreach (var item in cliente)
				{
					modelCliente = new ClienteModel()
					{
						ID = item.ID,
						Nome = item.Nome,
						Documento = item.Documento,
						Email = item.Email,
						Telefone = item.Telefone,
						Responsavel = item.Responsavel,
						Endereco = item.Endereco,
						Numero = item.Numero,
						Complemento = item.Complemento,
						Bairro = item.Bairro,
						Cidade = item.Cidade,
						Estado = item.Estado,
						Cep = item.Cep,
						Cod_Empresa = item.Cod_Empresa,
						User_Cad = item.User_Cad,
					};
				}

				model.Cliente = modelCliente;

				var modelo = _pmocModelo.ImportarPmocModelo(equipamento.Pmoc_Modelo_ID, equipamento.Cod_Empresa).Result;

				if (modelo == null)
					throw new Exception("Modelo de PMOC vincula a este enquipamento não encontrado.");

				model.Modelo = modelo;

				var itens = _pmocModeloItens.ImportarListaItensPorModelo(equipamento.Pmoc_Modelo_ID, equipamento.Cod_Empresa);

				foreach ( var i in itens)
				{
					//var plano = _pmocPlano.GetPmocPlanoForId(equipamento.Cliente_ID, equipamento.Cod_Empresa).Result;
					var plano = _pmocPlano.GetPmocPlanoForId(1, equipamento.Cod_Empresa).Result;

					if (plano != null)
					{
						plano.Periodo_Ini = plano.Periodo_Ini.AddYears(1);
						plano.Periodo_Fim = plano.Periodo_Fim.AddYears(1);
						//AQUI PRECISA TER UMA LÓGICA ONDE SE ANALISA A FREQUENCIA DO ITEM DO MODELO,
						//E CONFORME A FRENQUENCIA VERIFICA SE ESTÁ NO PERÍODO DE MANUTENÇÃO DAQUELE ITEM DO MODELO
						//ANTES VERIFICA SE O PLANO ESTÁ ATIVO E DENTRO DA VIGENCIA
						if ((plano.Periodo_Ini <= DateTime.Now && plano.Periodo_Fim >= DateTime.Now) && plano.Ativo == 1) //1 = Ativo
						{
							ItemViewModel item = new ItemViewModel() 
							{
								ID = (int)i.ID,
								Descricao = i.Descricao,
								Frequencia = i.Frequencia
							};

							listItems.Add(item);
						}
						else
						{
							throw new Exception("Plano de PMOC inativo ou com o período de vigência encerrado. Favor verificar.");
						}
					}
					else
					{
						throw new Exception("Plano de PMOC não pode retornar nulo.");
					}
				}
				
				model.Itens = listItems;
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return model;
		}

		public bool InsertOperacao(PmocOperacaoCadViewModel model)
		{
			bool output = false;
			PmocOperacaoModel operacao = new PmocOperacaoModel();
			List<PmocOperacaoModel> lista = new List<PmocOperacaoModel>();
			PmocOperacaoHelper helper = new PmocOperacaoHelper();

			try
			{
				var selecionados = model.Itens.Where(i => i.Selecionado).ToList();								

				foreach (var i in model.Itens)
				{
					if (i.Selecionado == true)
					{
						operacao.Cod_Empresa = model.Cod_Empresa;
						operacao.Cliente_Id = model.Cliente_Id;
						operacao.Equipamento_Id = model.Equipamento_Id;
						operacao.Modelo_Id = model.Modelo_Id;
						operacao.Dt_Ultima_Visita = model.Dt_Ultima_Visita;
						operacao.User_Cad = model.UserCad;

						operacao.Modelo_Item_Id = i.ID;

						operacao.Dt_Proxima_Visita = helper.ObterDataManutencao(i.Frequencia, operacao.Dt_Ultima_Visita);

						var teste = operacao;

						lista.Add(operacao);
					}
										
					operacao = new PmocOperacaoModel();
				}
								
				if (lista.Count == selecionados.Count)
					output = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;	
		}
	}
}
