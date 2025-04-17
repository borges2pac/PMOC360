using B.OS.WEB.Context;
using B.OS.WEB.Models.Repository.Interfaces;

namespace B.OS.WEB.Models.Repository
{
	public class FaturaRepository : BaseRepository<TabFatura>, IFaturaRepository
	{
		private readonly OrdemServicoContext _dbContext;

		public FaturaRepository(OrdemServicoContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
