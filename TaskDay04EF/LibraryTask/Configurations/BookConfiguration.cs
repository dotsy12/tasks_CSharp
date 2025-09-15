using LibraryTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LibraryTask.Configurations
{
	public class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.ToTable("Books");

			builder.HasKey(b => b.Id);

			builder.Property(b => b.Id)
				.ValueGeneratedOnAdd();

			builder.Property(b => b.Title)
				.IsRequired()
				.HasMaxLength(300);

			builder.Property(b => b.ISBN)
				.IsRequired()
				.HasMaxLength(13)
				.IsFixedLength(false);

			builder.Property(b => b.AuthorId)
				.IsRequired();

			// Relationships
			builder.HasOne(b => b.Author)
				.WithMany(a => a.Books)
				.HasForeignKey(b => b.AuthorId)
				.OnDelete(DeleteBehavior.Restrict);

			// Indexes
			builder.HasIndex(b => b.ISBN)
				.IsUnique();
			builder.HasIndex(b => b.Title);
			builder.HasIndex(b => b.AuthorId);
		}

		
	}

}
