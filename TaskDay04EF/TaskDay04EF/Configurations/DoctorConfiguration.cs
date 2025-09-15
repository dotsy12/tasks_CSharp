using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TaskDay04EF.models;

namespace TaskDay04EF.Configurations
{
	public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
	{
		public void Configure(EntityTypeBuilder<Doctor> builder)
		{
			builder.ToTable("Doctors");

			builder.HasKey(d => d.Id);

			builder.Property(d => d.Id)
				.ValueGeneratedOnAdd();

			builder.Property(d => d.Name)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(d => d.Specialization)
				.IsRequired()
				.HasMaxLength(150);

			builder.Property(d => d.Phone)
				.IsRequired()
				.HasMaxLength(20);

			builder.Property(d => d.Email)
				.IsRequired()
				.HasMaxLength(250);

			builder.Property(d => d.ConsultationFee)
				.HasColumnType("decimal(10,2)")
				.IsRequired();

			// Indexes
			builder.HasIndex(d => d.Email)
				.IsUnique();
			builder.HasIndex(d => d.Specialization);
			builder.HasIndex(d => d.Name);
		}
	}
}
