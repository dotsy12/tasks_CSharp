

using E_commerce.Models.EcommerceSystem.Models;

using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	namespace EcommerceSystem.Configurations
	{
		public class OrderConfiguration : IEntityTypeConfiguration<Order>
		{
			public void Configure(EntityTypeBuilder<Order> builder)
			{
				builder.HasKey(o => o.Id);

				builder.Property(o => o.OrderDate)
					.IsRequired();

				// Many-to-One: Order to Customer
				builder.HasOne(o => o.Customer)
					.WithMany(c => c.Orders)
					.HasForeignKey(o => o.CustomerId)
					.OnDelete(DeleteBehavior.Cascade);
			}
		}
	}


