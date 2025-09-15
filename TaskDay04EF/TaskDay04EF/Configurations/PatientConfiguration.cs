using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TaskDay04EF.models;

namespace TaskDay04EF.Configurations
{
	public class PatientConfiguration : IEntityTypeConfiguration<Patient>
	{
		public void Configure(EntityTypeBuilder<Patient> builder)
		{
			builder.ToTable("Patients");

			builder.HasKey(p => p.Id);

			builder.Property(p => p.Id)
				.ValueGeneratedOnAdd();

			builder.Property(p => p.Name)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(p => p.DateOfBirth)
				.IsRequired()
				.HasColumnType("date");

			builder.Property(p => p.Phone)
				.IsRequired()
				.HasMaxLength(20);

			builder.Property(p => p.Address)
				.IsRequired()
				.HasMaxLength(500);

			builder.Property(p => p.Email)
				.HasMaxLength(250);

			// Indexes
			builder.HasIndex(p => p.Email)
				.IsUnique()
				.HasFilter("[Email] IS NOT NULL");
			builder.HasIndex(p => p.Phone);
			builder.HasIndex(p => p.Name);
		}
	}
}
