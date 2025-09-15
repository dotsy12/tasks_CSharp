using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay04EF.models
{
	public class Appointment
	{
		public int Id { get; set; }
		public int PatientId { get; set; }
		public int DoctorId { get; set; }
		public DateTime AppointmentDate { get; set; }
		public TimeSpan Duration { get; set; }
		public AppointmentStatus Status { get; set; }
		public string? Notes { get; set; }
		public decimal Fee { get; set; }

		// Navigation Properties
		public Patient Patient { get; set; }
		public Doctor Doctor { get; set; }
	}
}
