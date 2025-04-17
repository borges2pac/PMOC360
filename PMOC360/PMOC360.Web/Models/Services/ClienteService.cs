using PMOC360.Web.Models.Models;
using PMOC360.Web.Models.Repository.Interfaces;
using PMOC360.Web.Models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PMOC360.Web.Models.Services
{
	public class ClienteService : IClienteService
	{
		private readonly IClienteRepository _repository;

		public ClienteService(IClienteRepository repository)
		{
			_repository = repository;
		}

		public string Alterar(ClienteModel model)
		{
			try
			{
				return _repository.UpdateCliente(model);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string Excluir(int id, int empresaId, string user)
		{
			try
			{
				return _repository.DesativaCliente(id, empresaId, user);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public IEnumerable<ClienteViewModel> GetAll(int empresaId)
		{
			List<ClienteViewModel> listaClientes = new List<ClienteViewModel>();
			ClienteViewModel model = new ClienteViewModel();

			try
			{
				var list = _repository.GetAllClientes(empresaId);

				if(list.Count > 0)
				{
					foreach (var item in list)
					{
						model = new ClienteViewModel()
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
							Ativo = item.Ativo,
							EmpresaId = item.Cod_Empresa,
							UserAlt = item.User_Alt,
							UserCad = item.User_Cad,
							DataAlt = string.IsNullOrEmpty(item.Data_Alt.ToString()) ? new DateTime() : Convert.ToDateTime(item.Data_Alt.ToString()),
							DataCad = string.IsNullOrEmpty(item.Data_Cad.ToString()) ? new DateTime() : Convert.ToDateTime(item.Data_Cad.ToString()),
						};

						listaClientes.Add(model);
					}
				}
				else
				{
					listaClientes = new List<ClienteViewModel>();
				}

				return listaClientes;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public IEnumerable<ClienteModel> GetAllForId(int id, int empresaId)
		{
			throw new NotImplementedException();
		}

		public ClienteModel GetForId(int id, int empresaId)
		{
			ClienteModel cliente = new ClienteModel();
			try
			{
				var retorno = _repository.GetClientesById(id, empresaId);

				if(retorno.Count > 0 || retorno.Count < 2)
				{
					foreach (var item in retorno) 
					{
						cliente = new ClienteModel() 
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
				}

				return cliente;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string Incluir(ClienteModel model)
		{
			string output = string.Empty;

			try
			{
				if (model == null) 
				{
					throw new Exception("registro de clientes não pode ser nulo.");
				}
				else
				{
					output = _repository.CadastrarCliente(model);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}

		IEnumerable<ClienteModel> IService<ClienteModel>.GetAll(int empresaId)
		{
			throw new NotImplementedException();
		}
	}
}
