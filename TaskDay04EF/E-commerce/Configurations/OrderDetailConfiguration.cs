
	using E_commerce.Models.EcommerceSystem.Models;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	namespace EcommerceSystem.Configurations
	{
		public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
		{
			public void Configure(EntityTypeBuilder<OrderDetail> builder)
			{
				// Composite Primary Key
				builder.HasKey(od => new { od.OrderId, od.ProductId });

				builder.Property(od => od.Quantity)
					.IsRequired();

				// Many-to-Many relationship through OrderDetail
				builder.HasOne(od => od.Order)
					.WithMany(o => o.OrderDetails)
					.HasForeignKey(od => od.OrderId)
					.OnDelete(DeleteBehavior.Cascade);

				builder.HasOne(od => od.Product)
					.WithMany(p => p.OrderDetails)
					.HasForeignKey(od => od.ProductId)
					.OnDelete(DeleteBehavior.Cascade);
			}
		}
	}

