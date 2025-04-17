using B.OS.WEB.Context;
using B.OS.WEB.Models.Repository.Interfaces;

namespace B.OS.WEB.Models.Repository
{
	public class ClienteRepository : BaseRepository<TabCliente>, IClienteRepository
	{
		private readonly OrdemServicoContext _dbContext;

		public ClienteRepository(OrdemServicoContext dbContext):base(dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
