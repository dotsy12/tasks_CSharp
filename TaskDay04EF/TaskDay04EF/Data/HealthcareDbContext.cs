using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TaskDay04EF.models;
using Microsoft.EntityFrameworkCore;

namespace TaskDay04EF.Data
{
	public class HealthcareDbContext : DbContext
	{
		public HealthcareDbContext(DbContextOptions<HealthcareDbContext> options)
			: base(options)
		{
		}

		public DbSet<Patient> Patients { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Appointment> Appointments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Apply all configurations from the assembly
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(HealthcareDbContext).Assembly);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=.;Database=HealthcareDB;Trusted_Connection=true;MultipleActiveResultSets=true");
			}
		}
	}

}
