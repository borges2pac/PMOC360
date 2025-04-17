namespace B.OS.WEB
{
	public class Config
	{
		public static IConfiguration configuration = new ConfigurationBuilder()
			.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
			.AddJsonFile("appsettings.json", optional: false)
			.AddJsonFile($"appsettings.json", optional: false)
			.Build();

		public static string getConn
		{
			get
			{
				return configuration.GetConnectionString("acesso");
			}
		}
	}
}
