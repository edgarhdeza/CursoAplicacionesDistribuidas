using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Responses.Catalog
{
	public class CatalogResponse
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public int CategoryId { get; set; }
		public string Description { get; set; } = null!;
		public string Summary { get; set; } = null!;
		public decimal Price { get; set; }
		public string? PhotoURL { get; set; }
	}
}
