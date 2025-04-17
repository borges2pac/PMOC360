using System.ComponentModel.DataAnnotations.Schema;

namespace B.OS.WEB.Models
{
	public class BaseEntity
	{
		[NotMapped]
		public string[] pesquisaTermo 
		{
			get 
			{
				return GetType()
					.GetProperties()
					.Where(t => t.PropertyType == typeof(string))
					.Select(t => (string)t.GetValue(this) ?? "")
					.ToArray();
			}
		}

		[NotMapped]
		public int IncluirAlterar { get; set; }
	}
}
