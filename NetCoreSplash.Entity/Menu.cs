using System.Collections.Generic;

namespace NetCoreSplash.Entity
{
	public class Menu
	{		
		public int Id { get; set; }
		public string Controller { get; set; }
		public string Action { get; set; }
		public string Label { get; set; }
		public string ClassCss { get; set; }
		public string Area { get; set; }
		public int? IdMenu { get; set; }
		public virtual ICollection<Menu> Itens { get; set; }
	}
}
