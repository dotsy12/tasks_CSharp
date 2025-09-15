using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay04EF.models
{
	public class Doctor
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Specialization { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public decimal ConsultationFee { get; set; }

		// Navigation Properties
		public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
	}
}
