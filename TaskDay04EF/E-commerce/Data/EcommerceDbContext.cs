
using EcommerceSystem.Configurations;
using Microsoft.EntityFrameworkCore;
using E_commerce.models.EcommerceSystem.Models;
using E_commerce.Models.EcommerceSystem.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace EcommerceSystem.Data
{
	public class EcommerceDbContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }

		public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Apply all configurations using Fluent API
			modelBuilder.ApplyConfiguration(new CustomerConfiguration());
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new OrderConfiguration());
			modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());

			base.OnModelCreating(modelBuilder);
		}

		// Optional: Override SaveChanges to add timestamps
		public override int SaveChanges()
		{
			AddTimestamps();
			return base.SaveChanges();
		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			AddTimestamps();
			return await base.SaveChangesAsync(cancellationToken);
		}

		private void AddTimestamps()
		{
			var entities = ChangeTracker.Entries()
				.Where(x => x.Entity is Order && (x.State == EntityState.Added || x.State == EntityState.Modified));

			foreach (var entity in entities)
			{
				var now = DateTime.UtcNow;

				if (entity.State == EntityState.Added)
				{
					((Order)entity.Entity).OrderDate = now;
				}
			}
		}
	}
}