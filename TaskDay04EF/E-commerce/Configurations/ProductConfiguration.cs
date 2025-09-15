using E_commerce.Models.EcommerceSystem.Models;

using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	namespace EcommerceSystem.Configurations
	{
		public class ProductConfiguration : IEntityTypeConfiguration<Product>
		{
			public void Configure(EntityTypeBuilder<Product> builder)
			{
				builder.HasKey(p => p.Id);

				builder.Property(p => p.Name)
					.IsRequired()
					.HasMaxLength(200);

				builder.Property(p => p.Price)
					.HasPrecision(18, 2);

				// Many-to-One: Product to Category
				builder.HasOne(p => p.Category)
					.WithMany(c => c.Products)
					.HasForeignKey(p => p.CategoryId)
					.OnDelete(DeleteBehavior.Cascade);
			}
		}
	}


