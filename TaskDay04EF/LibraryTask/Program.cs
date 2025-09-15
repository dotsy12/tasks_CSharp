
using LibraryTask.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EFRelationshipsDemo.Data;
public class Program
{
	public static void Main(string[] args)
	{
		using var context = new LibraryDbContext(new DbContextOptions<LibraryDbContext>());
		Console.WriteLine("Starting Library Console App...");

		

		// عمل Seed للبيانات
		SeedLibraryData(context);

		Console.WriteLine("Seeding completed successfully!");
		Console.ReadKey();
	}

	private static void SeedLibraryData(LibraryDbContext context)
	{
		
		context.Database.EnsureCreated();

		if (!context.Authors.Any())
		{
			var authors = new List<Author>
				{
					new Author { Name = "Naguib Mahfouz", BirthDate = new DateTime(1911, 12, 11) },
					new Author { Name = "Taha Hussein", BirthDate = new DateTime(1889, 11, 15) },
					new Author { Name = "Yusuf Idris", BirthDate = new DateTime(1927, 5, 19) }
				};

			context.Authors.AddRange(authors);
			context.SaveChanges();

			var books = new List<Book>
				{
					new Book { Title = "Cairo Trilogy", ISBN = "9780385264669", AuthorId = authors[0].Id },
					new Book { Title = "Children of Gebelawi", ISBN = "9780385264670", AuthorId = authors[0].Id },
					new Book { Title = "The Days", ISBN = "9780385264671", AuthorId = authors[1].Id },
					new Book { Title = "The Cheapest Nights", ISBN = "9780385264672", AuthorId = authors[2].Id }
				};

			context.Books.AddRange(books);

			var borrowers = new List<Borrower>
				{
					new Borrower { Name = "Mohamed Ali", MembershipDate = DateTime.Now.AddMonths(-6) },
					new Borrower { Name = "Fatima Hassan", MembershipDate = DateTime.Now.AddMonths(-3) },
					new Borrower { Name = "Omar Ahmed", MembershipDate = DateTime.Now.AddMonths(-1) }
				};

			context.Borrowers.AddRange(borrowers);
			context.SaveChanges();

			var loans = new List<Loan>
				{
					new Loan { BookId = books[0].Id, BorrowerId = borrowers[0].Id, LoanDate = DateTime.Now.AddDays(-10) },
					new Loan { BookId = books[1].Id, BorrowerId = borrowers[1].Id, LoanDate = DateTime.Now.AddDays(-5), ReturnDate = DateTime.Now.AddDays(-1) }
				};

			context.Loans.AddRange(loans);
			context.SaveChanges();
		}
	}
}