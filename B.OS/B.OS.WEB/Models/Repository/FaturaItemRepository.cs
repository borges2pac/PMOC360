using B.OS.WEB.Context;
using B.OS.WEB.Models.Repository.Interfaces;

namespace B.OS.WEB.Models.Repository
{
	public class FaturaItemRepository : BaseRepository<TabFaturaItens>, IFaturaItemRepository
	{
		private readonly OrdemServicoContext _dbContext;

		public FaturaItemRepository(OrdemServicoContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
