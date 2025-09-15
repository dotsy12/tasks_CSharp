using LibraryTask.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTask.Configurations
{
	public class LoanConfiguration : IEntityTypeConfiguration<Loan>
	{
		public void Configure(EntityTypeBuilder<Loan> builder)
		{
			builder.ToTable("Loans");

			// Composite Primary Key
			builder.HasKey(l => new { l.BookId, l.BorrowerId, l.LoanDate });

			builder.Property(l => l.LoanDate)
				.IsRequired()
				.HasDefaultValueSql("GETDATE()");

			builder.Property(l => l.ReturnDate)
				.IsRequired(false);

			// Relationships
			builder.HasOne(l => l.Book)
				.WithMany(b => b.Loans)
				.HasForeignKey(l => l.BookId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(l => l.Borrower)
				.WithMany(b => b.Loans)
				.HasForeignKey(l => l.BorrowerId)
				.OnDelete(DeleteBehavior.Cascade);

			// Indexes
			builder.HasIndex(l => l.LoanDate);
			builder.HasIndex(l => l.ReturnDate);
			builder.HasIndex(l => new { l.BookId, l.ReturnDate })
				.HasDatabaseName("IX_Book_ActiveLoans")
				.HasFilter("[ReturnDate] IS NULL"); // For active loans
		}
	}
}
