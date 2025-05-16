using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Responses.Basket
{
	public class BasketResponse
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
