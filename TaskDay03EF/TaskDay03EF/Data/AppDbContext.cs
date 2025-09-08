using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDay03EF.Models;

namespace TaskDay03EF.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<project> Projects { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=.;Database=ProjectDB;Trusted_Connection=true;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
			modelBuilder.Entity<project>(entity =>
			{
				
				entity.ToTable("Projects");

				
				entity.HasKey(e => e.id);
				entity.Property(e => e.id)
					.HasColumnName("Id")
					.UseIdentityColumn(10, 10); 

				
				entity.Property(e => e.name)
					.HasColumnName("Name")
					.HasColumnType("varchar(50)")
					.IsRequired()
					.HasDefaultValue("OurProject");

				
				entity.Property(e => e.cost)
					.HasColumnName("Cost")
					.HasColumnType("money")
					.IsRequired();

				
				entity.HasCheckConstraint("CK_Project_Cost",
					"Cost >= 500000 AND Cost <= 3500000");

				
				entity.HasIndex(e => e.name)
					.HasDatabaseName("IX_Project_Name");
			});
		}
	}

}
