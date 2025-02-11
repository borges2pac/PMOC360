using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMOC360.Domain.Models;
using PMOC360.Domain.Interfaces;
using PMOC360.API.Service.Interfaces;

namespace PMOC360.API.Service
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
			throw new NotImplementedException();
		}

		public string Excluir(int id, string user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ClienteModel> GetAll()
		{
			//List<ClienteModel> dto = new List<ClienteModel>();

			try
			{
				var list = _repository.GetAll();

				//foreach (var item in list)
				//{
				//	var cliente = new ClienteModel()
				//	{
				//		ID = item.ID,
				//		Nome = item.Nome,
				//		Documento = item.Documento,
				//		Email = item.Email,
				//		Telefone = item.Telefone,
				//		Responsavel = item.Responsavel,
				//		Endereco = item.Endereco,
				//		Numero = item.Numero,
				//		Complemento = item.Complemento,
				//		Bairro = item.Bairro,
				//		Cidade = item.Cidade,
				//		Estado = item.Estado,
				//		Cep = item.Cep,
				//		Ativo = item.Ativo,
				//		EmpresaId = item.EmpresaId,
				//		UserAlt = item.UserAlt,
				//		UserCad = item.UserCad,
				//		DataAlt = item.DataAlt,
				//		DataCad = item.DataCad
				//	};

				//	dto.Add(cliente);
				//}

				return list;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ClienteModel GetForId(int id)
		{
			throw new NotImplementedException();
		}

		public string Incluir(ClienteModel model)
		{
			string output = string.Empty;
			ClienteModel cliente = new ClienteModel();

			try
			{
				cliente = new ClienteModel() 
				{
					ID = model.ID,
					Nome = model.Nome,
					Documento = model.Documento,
					Email = model.Email,
					Telefone = model.Telefone,
					Responsavel = model.Responsavel,
					Endereco = model.Endereco,
					Numero = model.Numero,
					Complemento = model.Complemento,
					Bairro = model.Bairro,
					Cidade = model.Cidade,
					Estado = model.Estado,
					Cep = model.Cep,
					EmpresaId = model.EmpresaId,
					UserCad = model.UserCad,
				};

				output = _repository.Incluir(cliente);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}
	}
}
