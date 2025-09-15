using E_commerce.models.EcommerceSystem.Models;
using E_commerce.Models.EcommerceSystem.Models;
using EcommerceSystem.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace EcommerceSystem
{
	class Program
	{
		static async Task Main(string[] args)
		{
			// Create Host with DI container
			var host = CreateHostBuilder(args).Build();

			try
			{
				using (var scope = host.Services.CreateScope())
				{
					var context = scope.ServiceProvider.GetRequiredService<EcommerceDbContext>();
					var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

					// Ensure database is created
					await context.Database.EnsureCreatedAsync();
					logger.LogInformation("Database created/verified successfully");

					// Seed sample data
					await SeedDataAsync(context, logger);

					// Run demo operations
					await RunDemoOperationsAsync(context, logger);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}

			Console.WriteLine("\nPress any key to exit...");
			Console.ReadKey();
		}

		static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureServices((context, services) =>
				{
					// Configure EF Core with SQL Server
					services.AddDbContext<EcommerceDbContext>(options =>
						options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EcommerceDB;Trusted_Connection=true;"));

					services.AddLogging();
				});

		static async Task SeedDataAsync(EcommerceDbContext context, ILogger logger)
		{
			if (!context.Categories.Any())
			{
				logger.LogInformation("Seeding sample data...");

				// Add Categories
				var electronics = new Category { Name = "Electronics" };
				var clothing = new Category { Name = "Clothing" };
				var books = new Category { Name = "Books" };

				context.Categories.AddRange(electronics, clothing, books);
				await context.SaveChangesAsync();

				// Add Products
				var products = new List<Product>
				{
					new Product { Name = "Laptop", Price = 999.99m, CategoryId = electronics.Id },
					new Product { Name = "Smartphone", Price = 599.99m, CategoryId = electronics.Id },
					new Product { Name = "T-Shirt", Price = 19.99m, CategoryId = clothing.Id },
					new Product { Name = "Jeans", Price = 49.99m, CategoryId = clothing.Id },
					new Product { Name = "Programming Book", Price = 39.99m, CategoryId = books.Id }
				};

				context.Products.AddRange(products);
				await context.SaveChangesAsync();

				// Add Customers
				var customers = new List<Customer>
				{
					new Customer { Name = "Ahmed Ali", Email = "ahmed@example.com" },
					new Customer { Name = "Sara Mohamed", Email = "sara@example.com" },
					new Customer { Name = "Omar Hassan", Email = "omar@example.com" }
				};

				context.Customers.AddRange(customers);
				await context.SaveChangesAsync();

				// Add Orders
				var order1 = new Order { OrderDate = DateTime.Now.AddDays(-5), CustomerId = customers[0].Id };
				var order2 = new Order { OrderDate = DateTime.Now.AddDays(-2), CustomerId = customers[1].Id };

				context.Orders.AddRange(order1, order2);
				await context.SaveChangesAsync();

				// Add Order Details
				var orderDetails = new List<OrderDetail>
				{
					new OrderDetail { OrderId = order1.Id, ProductId = products[0].Id, Quantity = 1 },
					new OrderDetail { OrderId = order1.Id, ProductId = products[2].Id, Quantity = 2 },
					new OrderDetail { OrderId = order2.Id, ProductId = products[1].Id, Quantity = 1 },
					new OrderDetail { OrderId = order2.Id, ProductId = products[4].Id, Quantity = 3 }
				};

				context.OrderDetails.AddRange(orderDetails);
				await context.SaveChangesAsync();

				logger.LogInformation("Sample data seeded successfully");
			}
		}

		static async Task RunDemoOperationsAsync(EcommerceDbContext context, ILogger logger)
		{
			Console.WriteLine("=== E-commerce System Demo ===\n");

			// Display all categories with products
			Console.WriteLine("1. Categories with Products:");
			var categoriesWithProducts = await context.Categories
				.Include(c => c.Products)
				.ToListAsync();

			foreach (var category in categoriesWithProducts)
			{
				Console.WriteLine($"Category: {category.Name}");
				foreach (var product in category.Products)
				{
					Console.WriteLine($"  - {product.Name}: ${product.Price}");
				}
				Console.WriteLine();
			}

			// Display all orders with customer and order details
			Console.WriteLine("2. Orders with Customer Info and Products:");
			var ordersWithDetails = await context.Orders
				.Include(o => o.Customer)
				.Include(o => o.OrderDetails)
					.ThenInclude(od => od.Product)
				.ToListAsync();

			foreach (var order in ordersWithDetails)
			{
				Console.WriteLine($"Order #{order.Id} - Date: {order.OrderDate:yyyy-MM-dd}");
				Console.WriteLine($"Customer: {order.Customer.Name} ({order.Customer.Email})");
				Console.WriteLine("Products:");

				decimal totalAmount = 0;
				foreach (var detail in order.OrderDetails)
				{
					var itemTotal = detail.Product.Price * detail.Quantity;
					totalAmount += itemTotal;
					Console.WriteLine($"  - {detail.Product.Name} x{detail.Quantity} = ${itemTotal}");
				}
				Console.WriteLine($"Total Amount: ${totalAmount}");
				Console.WriteLine();
			}

			// Display products by category
			Console.WriteLine("3. Products grouped by Category:");
			var productsByCategory = await context.Products
				.Include(p => p.Category)
				.GroupBy(p => p.Category.Name)
				.ToListAsync();

			foreach (var group in productsByCategory)
			{
				Console.WriteLine($"{group.Key} ({group.Count()} products):");
				foreach (var product in group)
				{
					Console.WriteLine($"  - {product.Name}: ${product.Price}");
				}
				Console.WriteLine();
			}

			// Display customer order history
			Console.WriteLine("4. Customer Order History:");
			var customersWithOrders = await context.Customers
				.Include(c => c.Orders)
					.ThenInclude(o => o.OrderDetails)
						.ThenInclude(od => od.Product)
				.ToListAsync();

			foreach (var customer in customersWithOrders)
			{
				Console.WriteLine($"Customer: {customer.Name}");
				Console.WriteLine($"Total Orders: {customer.Orders.Count}");

				decimal totalSpent = 0;
				foreach (var order in customer.Orders)
				{
					var orderTotal = order.OrderDetails.Sum(od => od.Product.Price * od.Quantity);
					totalSpent += orderTotal;
					Console.WriteLine($"  Order #{order.Id}: ${orderTotal} on {order.OrderDate:yyyy-MM-dd}");
				}
				Console.WriteLine($"Total Spent: ${totalSpent}");
				Console.WriteLine();
			}

			logger.LogInformation("Demo operations completed successfully");
		}
	}
}