using B.OS.WEB.Models;
using Microsoft.EntityFrameworkCore;

namespace B.OS.WEB.Context
{
	public partial class OrdemServicoContext : DbContext
	{
		public OrdemServicoContext()
		{
				
		}

		public OrdemServicoContext(DbContextOptions<OrdemServicoContext> options) : base(options)
		{
			
		}

		public virtual DbSet<TabCliente> TabCliente { get; set; }
		public virtual DbSet<TabFatura> TabFatura { get; set; }
		public virtual DbSet<TabFaturaItens> TabFaturaItens { get; set; }
		public virtual DbSet<TabOrdemServico> TabOrdemServico{ get; set; }
	}
}
