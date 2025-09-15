using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.models
{
	using E_commerce.Models.EcommerceSystem.Models;
	using System.Collections.Generic;

	namespace EcommerceSystem.Models
	{
		public class Customer
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public string Email { get; set; }

			// Navigation Properties
			public virtual ICollection<Order> Orders { get; set; }

			public Customer()
			{
				Orders = new HashSet<Order>();
			}
		}
	}
}
