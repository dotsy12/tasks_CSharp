

using LibraryTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryTask.Configurations
{
	public class AuthorConfiguration : IEntityTypeConfiguration<Author>
	{
		public void Configure(EntityTypeBuilder<Author> builder)
		{
			builder.ToTable("Authors");

			builder.HasKey(a => a.Id);

			builder.Property(a => a.Id)
				.ValueGeneratedOnAdd();

			builder.Property(a => a.Name)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(a => a.BirthDate)
				.IsRequired()
				.HasColumnType("date");

			// Index
			builder.HasIndex(a => a.Name);
		}
	}
}
