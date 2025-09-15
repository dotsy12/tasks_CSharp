using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TaskDay04EF.models;

namespace TaskDay04EF.Configurations
{
	public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
	{
		public void Configure(EntityTypeBuilder<Appointment> builder)
		{
			builder.ToTable("Appointments");

			builder.HasKey(a => a.Id);

			builder.Property(a => a.Id)
				.ValueGeneratedOnAdd();

			builder.Property(a => a.PatientId)
				.IsRequired();

			builder.Property(a => a.DoctorId)
				.IsRequired();

			builder.Property(a => a.AppointmentDate)
				.IsRequired();

			builder.Property(a => a.Duration)
				.IsRequired()
				.HasDefaultValue(TimeSpan.FromMinutes(30));

			builder.Property(a => a.Status)
				.IsRequired()
				.HasDefaultValue(AppointmentStatus.Scheduled)
				.HasConversion<int>();

			builder.Property(a => a.Notes)
				.HasMaxLength(1000);

			builder.Property(a => a.Fee)
				.HasColumnType("decimal(10,2)")
				.IsRequired();

			// Relationships
			builder.HasOne(a => a.Patient)
				.WithMany(p => p.Appointments)
				.HasForeignKey(a => a.PatientId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(a => a.Doctor)
				.WithMany(d => d.Appointments)
				.HasForeignKey(a => a.DoctorId)
				.OnDelete(DeleteBehavior.Restrict);

			// Indexes
			builder.HasIndex(a => a.AppointmentDate);
			builder.HasIndex(a => a.Status);
			builder.HasIndex(a => new { a.DoctorId, a.AppointmentDate })
				.HasDatabaseName("IX_Doctor_AppointmentDate");
			builder.HasIndex(a => new { a.PatientId, a.AppointmentDate })
				.HasDatabaseName("IX_Patient_AppointmentDate");

			// Unique constraint to prevent double booking
			builder.HasIndex(a => new { a.DoctorId, a.AppointmentDate })
				.IsUnique()
				.HasDatabaseName("IX_Doctor_Unique_Appointment")
				.HasFilter("[Status] IN (1, 2, 3)"); // Scheduled, Confirmed, InProgress
		}
	}
}
