using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Models
{
	using System.Collections.Generic;

	namespace EcommerceSystem.Models
	{
		public class Product
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public decimal Price { get; set; }
			public int CategoryId { get; set; }

			// Navigation Properties
			public virtual Category Category { get; set; }
			public virtual ICollection<OrderDetail> OrderDetails { get; set; }

			public Product()
			{
				OrderDetails = new HashSet<OrderDetail>();
			}
		}
	}

}
