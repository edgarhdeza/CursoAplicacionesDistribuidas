﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Domain.Contracts
{
	public abstract class AuditableEntity<TId> : IAuditableEntity<TId>
	{
		public string CreatedBy { get; set; } = null!;
		public DateTime CreatedOn { get; set; }
		public string? LastModifiedBy { get; set; }
		public DateTime? LastModifiedOn { get; set; }
		public TId Id { get; set; }
	}
}
