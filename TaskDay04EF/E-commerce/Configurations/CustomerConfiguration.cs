using E_commerce.models.EcommerceSystem.Models;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceSystem.Configurations
	{
		public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
		{
			public void Configure(EntityTypeBuilder<Customer> builder)
			{
				builder.HasKey(c => c.Id);

				builder.Property(c => c.Name)
					.IsRequired()
					.HasMaxLength(100);

				builder.Property(c => c.Email)
					.IsRequired()
					.HasMaxLength(255);

				builder.HasIndex(c => c.Email)
					.IsUnique();

				// One-to-Many: Customer to Orders
				builder.HasMany(c => c.Orders)
					.WithOne(o => o.Customer)
					.HasForeignKey(o => o.CustomerId)
					.OnDelete(DeleteBehavior.Cascade);
			}
		}
	}


