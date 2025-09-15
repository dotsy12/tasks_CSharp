using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay04EF.models
{
	public class Patient
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }

		// Navigation Properties
		public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
	}

}
