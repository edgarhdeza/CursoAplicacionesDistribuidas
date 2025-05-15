using DWShop.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Domain.Entities
{
	public class Category : AuditableEntity<int>
	{
		public string Name { get; set; }

		public virtual ICollection<Catalog> Catalogs { get; set; }
	}
}
