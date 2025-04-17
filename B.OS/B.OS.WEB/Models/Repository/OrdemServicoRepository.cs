using B.OS.WEB.Context;
using B.OS.WEB.Models.Repository.Interfaces;

namespace B.OS.WEB.Models.Repository
{
	public class OrdemServicoRepository: BaseRepository<TabOrdemServico>, IOrdemServicoRepository
	{
		private readonly OrdemServicoContext _dbContext;

		public OrdemServicoRepository(OrdemServicoContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
