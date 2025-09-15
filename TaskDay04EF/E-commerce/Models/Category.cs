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
		public class Category
		{
			public int Id { get; set; }
			public string Name { get; set; }

			// Navigation Properties
			public virtual ICollection<Product> Products { get; set; }

			public Category()
			{
				Products = new HashSet<Product>();
			}
		}
	}
}
