using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Models
{
	using E_commerce.models.EcommerceSystem.Models;
	using System;
	using System.Collections.Generic;

	namespace EcommerceSystem.Models
	{
		public class Order
		{
			public int Id { get; set; }
			public DateTime OrderDate { get; set; }
			public int CustomerId { get; set; }

			// Navigation Properties
			public virtual Customer Customer { get; set; }
			public virtual ICollection<OrderDetail> OrderDetails { get; set; }

			public Order()
			{
				OrderDetails = new HashSet<OrderDetail>();
			}
		}
	}
}
