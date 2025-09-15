using LibraryTask.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace LibraryTask.Configurations
{
	public class BorrowerConfiguration : IEntityTypeConfiguration<Borrower>
	{
		public void Configure(EntityTypeBuilder<Borrower> builder)
		{
			builder.ToTable("Borrowers");

			builder.HasKey(b => b.Id);

			builder.Property(b => b.Id)
				.ValueGeneratedOnAdd();

			builder.Property(b => b.Name)
				.IsRequired()
				.HasMaxLength(150);

			builder.Property(b => b.MembershipDate)
				.IsRequired()
				.HasDefaultValueSql("GETDATE()");

			// Index
			builder.HasIndex(b => b.Name);
			builder.HasIndex(b => b.MembershipDate);
		}
	}
}
