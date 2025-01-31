using PMOC360.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMOC360.Domain.Models;
using PMOC360.Domain.Interfaces;
using PMOC360.Service.Dto;

namespace PMOC360.Service.Services
{
	public class ClienteService : IClienteService
	{
		private readonly IClienteRepository _repository;

		public ClienteService(IClienteRepository repository)
		{
			_repository = repository;
		}

		public string Alterar(ClienteDto model)
		{
			throw new NotImplementedException();
		}

		public string Excluir(int id, string user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ClienteDto> GetAll()
		{
			List<ClienteDto> dto = new List<ClienteDto>();

			try
			{
				var list = _repository.GetAll();

				foreach (var item in list)
				{
					var cliente = new ClienteDto()
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
						EmpresaId = item.EmpresaId,
						UserAlt = item.UserAlt,
						UserCad = item.UserCad,
						DataAlt = item.DataAlt,
						DataCad = item.DataCad
					};

					dto.Add(cliente);
				}

				return dto;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ClienteDto GetForId(int id)
		{
			throw new NotImplementedException();
		}

		public string Incluir(ClienteDto model)
		{
			throw new NotImplementedException();
		}
	}
}
