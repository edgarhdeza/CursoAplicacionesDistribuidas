using DWShop.Domain.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace DWShop.Domain.Entities
{
	public class Catalog : AuditableEntity<int>
	{
		public string Name { get; set; } = null!;
		public int CategoryId {  get; set; }
		[ForeignKey("CategoryId")]
		public virtual Category Category { get; set; }
		public string Description { get; set; } = null!;
		public string Summary { get; set; } = null!;
		public decimal Price { get; set; }
		public string? PhotoURL { get; set; }
	}
}
