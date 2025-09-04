using System;
using System.Linq;

namespace TaskDay02EF
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region LINQ - Restriction Operators

			Console.WriteLine("=== LINQ - Restriction Operators ===");

			// 1. Find all products that are out of stock
			Console.WriteLine("1. Products out of stock:");
			var outOfStockProducts = ListGenerators.ProductList.Where(p => p.UnitsInStock == 0);
			foreach (var product in outOfStockProducts)
				Console.WriteLine($"   {product.ProductName}");

			// 2. Find all products that are in stock and cost more than 3.00 per unit
			Console.WriteLine("\n2. Products in stock and cost > 3.00:");
			var expensiveInStockProducts = ListGenerators.ProductList
				.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00m);
			foreach (var product in expensiveInStockProducts)
				Console.WriteLine($"   {product.ProductName} - Price: {product.UnitPrice:C}");

			// 3. Returns digits whose name is shorter than their value
			Console.WriteLine("\n3. Digits whose name is shorter than their value:");
			string[] digitNames = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
			var shortNamedDigits = digitNames.Where((name, index) => name.Length < index);
			foreach (var digit in shortNamedDigits)
				Console.WriteLine($"   {digit}");

			#endregion


			#region LINQ - Element Operators

			Console.WriteLine("\n=== LINQ - Element Operators ===");

			// 1. Get first Product out of Stock
			Console.WriteLine("1. First product out of stock:");
			var firstOutOfStock = ListGenerators.ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
			Console.WriteLine($"   {firstOutOfStock?.ProductName ?? "None"}");

			// 2. Return the first product whose Price > 1000, unless there is no match
			Console.WriteLine("\n2. First product with price > 1000:");
			var expensiveProduct = ListGenerators.ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
			Console.WriteLine($"   {expensiveProduct?.ProductName ?? "None"}");

			// 3. Retrieve the second number greater than 5
			Console.WriteLine("\n3. Second number greater than 5:");
			int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
			var secondGreaterThan5 = numbers.Where(n => n > 5).Skip(1).FirstOrDefault();
			Console.WriteLine($"   {secondGreaterThan5}");

			#endregion

			#region LINQ - Aggregate Operators

			Console.WriteLine("\n=== LINQ - Aggregate Operators ===");

			// 1. Count of odd numbers in array
			Console.WriteLine("1. Count of odd numbers:");
			int[] arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
			var oddCount = arr.Count(n => n % 2 == 1);
			Console.WriteLine($"   {oddCount}");

			// 2. List of customers and how many orders each has
			Console.WriteLine("\n2. Customers and their order count:");
			var customerOrderCounts = ListGenerators.CustomerList
				.Select(c => new { CustomerName = c.Name, OrderCount = c.Orders?.Length ?? 0 });
			foreach (var customer in customerOrderCounts)
				Console.WriteLine($"   {customer.CustomerName}: {customer.OrderCount} orders");

			// 3. List of categories and how many products each has
			Console.WriteLine("\n3. Categories and product count:");
			var categoryProductCounts = ListGenerators.ProductList
				.GroupBy(p => p.Category)
				.Select(g => new { Category = g.Key, ProductCount = g.Count() });
			foreach (var category in categoryProductCounts)
				Console.WriteLine($"   {category.Category}: {category.ProductCount} products");

			// 4. Total of numbers in array
			Console.WriteLine("\n4. Total of numbers in array:");
			var totalSum = arr.Sum();
			Console.WriteLine($"   {totalSum}");

			// 5. Total characters in dictionary (simulated - would need actual file)
			Console.WriteLine("\n5. Total characters in dictionary:");
			// This would require reading dictionary_english.txt file
			string[] sampleWords = { "apple", "banana", "cherry", "date", "elderberry" };
			var totalChars = sampleWords.Sum(w => w.Length);
			Console.WriteLine($"   Sample words total characters: {totalChars}");

			// 6. Total units in stock for each product category
			Console.WriteLine("\n6. Total units in stock by category:");
			var categoryStockTotals = ListGenerators.ProductList
				.GroupBy(p => p.Category)
				.Select(g => new { Category = g.Key, TotalUnits = g.Sum(p => p.UnitsInStock) });
			foreach (var category in categoryStockTotals)
				Console.WriteLine($"   {category.Category}: {category.TotalUnits} units");

			// 7. Length of shortest word (simulated)
			Console.WriteLine("\n7. Length of shortest word:");
			var shortestWordLength = sampleWords.Min(w => w.Length);
			Console.WriteLine($"   {shortestWordLength}");

			// 8. Cheapest price in each category
			Console.WriteLine("\n8. Cheapest price in each category:");
			var cheapestPrices = ListGenerators.ProductList
				.GroupBy(p => p.Category)
				.Select(g => new { Category = g.Key, CheapestPrice = g.Min(p => p.UnitPrice) });
			foreach (var category in cheapestPrices)
				Console.WriteLine($"   {category.Category}: {category.CheapestPrice:C}");

			// 9. Products with cheapest price in each category (using let)
			Console.WriteLine("\n9. Cheapest products in each category:");
			var cheapestProducts = from p in ListGenerators.ProductList
								   group p by p.Category into g
								   let minPrice = g.Min(product => product.UnitPrice)
								   select new { Category = g.Key, Products = g.Where(product => product.UnitPrice == minPrice) };
			foreach (var category in cheapestProducts)
			{
				Console.WriteLine($"   {category.Category}:");
				foreach (var product in category.Products)
					Console.WriteLine($"     {product.ProductName} - {product.UnitPrice:C}");
			}

			// 10. Length of longest word (simulated)
			Console.WriteLine("\n10. Length of longest word:");
			var longestWordLength = sampleWords.Max(w => w.Length);
			Console.WriteLine($"   {longestWordLength}");

			// 11. Most expensive price in each category
			Console.WriteLine("\n11. Most expensive price in each category:");
			var expensivePrices = ListGenerators.ProductList
				.GroupBy(p => p.Category)
				.Select(g => new { Category = g.Key, ExpensivePrice = g.Max(p => p.UnitPrice) });
			foreach (var category in expensivePrices)
				Console.WriteLine($"   {category.Category}: {category.ExpensivePrice:C}");

			// 12. Products with most expensive price in each category
			Console.WriteLine("\n12. Most expensive products in each category:");
			var expensiveProducts = ListGenerators.ProductList
				.GroupBy(p => p.Category)
				.Select(g => new {
					Category = g.Key,
					MaxPrice = g.Max(p => p.UnitPrice),
					Products = g.Where(p => p.UnitPrice == g.Max(pr => pr.UnitPrice))
				});
			foreach (var category in expensiveProducts)
			{
				Console.WriteLine($"   {category.Category}:");
				foreach (var product in category.Products)
					Console.WriteLine($"     {product.ProductName} - {product.UnitPrice:C}");
			}

			// 13. Average length of words (simulated)
			Console.WriteLine("\n13. Average length of words:");
			var avgWordLength = sampleWords.Average(w => w.Length);
			Console.WriteLine($"   {avgWordLength:F2}");

			// 14. Average price of each category's products
			Console.WriteLine("\n14. Average price by category:");
			var avgPrices = ListGenerators.ProductList
				.GroupBy(p => p.Category)
				.Select(g => new { Category = g.Key, AvgPrice = g.Average(p => p.UnitPrice) });
			foreach (var category in avgPrices)
				Console.WriteLine($"   {category.Category}: {category.AvgPrice:C}");

			#endregion

			#region LINQ - Ordering Operators

			Console.WriteLine("\n=== LINQ - Ordering Operators ===");

			// 1. Sort products by name
			Console.WriteLine("1. Products sorted by name:");
			var sortedByName = ListGenerators.ProductList.OrderBy(p => p.ProductName);
			foreach (var product in sortedByName.Take(5)) // Show first 5
				Console.WriteLine($"   {product.ProductName}");

			// 2. Case-insensitive sort of words
			Console.WriteLine("\n2. Case-insensitive sorted words:");
			string[] mixedCaseWords = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
			var sortedWords = mixedCaseWords.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);
			foreach (var word in sortedWords)
				Console.WriteLine($"   {word}");

			// 3. Sort products by units in stock (highest to lowest)
			Console.WriteLine("\n3. Products by units in stock (highest to lowest):");
			var sortedByStock = ListGenerators.ProductList.OrderByDescending(p => p.UnitsInStock);
			foreach (var product in sortedByStock.Take(5))
				Console.WriteLine($"   {product.ProductName}: {product.UnitsInStock} units");

			// 4. Sort digits by name length, then alphabetically
			Console.WriteLine("\n4. Digits sorted by name length, then alphabetically:");
			var sortedDigits = digitNames.OrderBy(d => d.Length).ThenBy(d => d);
			foreach (var digit in sortedDigits)
				Console.WriteLine($"   {digit}");

			// 5. Sort by word length then case-insensitive
			Console.WriteLine("\n5. Words sorted by length, then case-insensitive:");
			var sortedByLengthThenAlpha = mixedCaseWords
				.OrderBy(w => w.Length)
				.ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
			foreach (var word in sortedByLengthThenAlpha)
				Console.WriteLine($"   {word}");

			// 6. Sort products by category, then by unit price (highest to lowest)
			Console.WriteLine("\n6. Products by category, then price (high to low):");
			var sortedByCategoryThenPrice = ListGenerators.ProductList
				.OrderBy(p => p.Category)
				.ThenByDescending(p => p.UnitPrice);
			foreach (var product in sortedByCategoryThenPrice.Take(10))
				Console.WriteLine($"   {product.Category} - {product.ProductName}: {product.UnitPrice:C}");

			// 7. Sort by word length then case-insensitive descending
			Console.WriteLine("\n7. Words by length, then case-insensitive descending:");
			var sortedByLengthThenDescending = mixedCaseWords
				.OrderBy(w => w.Length)
				.ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);
			foreach (var word in sortedByLengthThenDescending)
				Console.WriteLine($"   {word}");

			// 8. Digits with second letter 'i' in reverse order
			Console.WriteLine("\n8. Digits with second letter 'i' (reversed):");
			var digitsWithI = digitNames
				.Where(d => d.Length > 1 && d[1] == 'i')
				.Reverse();
			foreach (var digit in digitsWithI)
				Console.WriteLine($"   {digit}");

			#endregion

			#region LINQ - Transformation Operators

			Console.WriteLine("\n=== LINQ - Transformation Operators ===");

			// 1. Sequence of product names only
			Console.WriteLine("1. Product names only:");
			var productNames = ListGenerators.ProductList.Select(p => p.ProductName);
			foreach (var name in productNames.Take(5))
				Console.WriteLine($"   {name}");

			// 2. Uppercase and lowercase versions of words
			Console.WriteLine("\n2. Uppercase and lowercase versions:");
			string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
			var caseVersions = words.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
			foreach (var version in caseVersions)
				Console.WriteLine($"   Upper: {version.Upper}, Lower: {version.Lower}");

			// 3. Product properties with UnitPrice renamed to Price
			Console.WriteLine("\n3. Products with renamed Price property:");
			var productInfo = ListGenerators.ProductList.Select(p => new
			{
				p.ProductID,
				p.ProductName,
				p.Category,
				Price = p.UnitPrice,
				p.UnitsInStock
			});
			foreach (var product in productInfo.Take(3))
				Console.WriteLine($"   {product.ProductName}: {product.Price:C}");

			// 4. Check if values match their position
			Console.WriteLine("\n4. Numbers matching their position:");
			int[] positionCheck = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
			var positionMatches = positionCheck.Select((value, index) => new
			{
				Number = value,
				InPlace = value == index
			});
			foreach (var match in positionMatches)
				Console.WriteLine($"   {match.Number}: {match.InPlace}");

			// 5. Pairs where numbersA < numbersB
			Console.WriteLine("\n5. Pairs where a < b:");
			int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
			int[] numbersB = { 1, 3, 5, 7, 8 };
			var pairs = from a in numbersA
						from b in numbersB
						where a < b
						select new { a, b };
			foreach (var pair in pairs.Take(10))
				Console.WriteLine($"   {pair.a} is less than {pair.b}");

			// 6. Orders with total < 500
			Console.WriteLine("\n6. Orders with total < 500:");
			var cheapOrders = from customer in ListGenerators.CustomerList
							  from order in customer.Orders ?? new Order[0]
							  where order.Total < 500
							  select new { customer.Name, order.Id, order.Total };
			foreach (var order in cheapOrders.Take(5))
				Console.WriteLine($"   Customer: {order.Name}, Order: {order.Id}, Total: {order.Total:C}");

			// 7. Orders made in 1998 or later
			Console.WriteLine("\n7. Orders from 1998 or later:");
			var recentOrders = from customer in ListGenerators.CustomerList
							   from order in customer.Orders ?? new Order[0]
							   where order.OrderDate.Year >= 1998
							   select new { customer.Name, order.Id, order.OrderDate };
			foreach (var order in recentOrders.Take(5))
				Console.WriteLine($"   Customer: {order.Name}, Order: {order.Id}, Date: {order.OrderDate:d}");

			#endregion

			#region LINQ - Partitioning Operators

			Console.WriteLine("\n=== LINQ - Partitioning Operators ===");

			// Note: Since we don't have Washington customers, I'll use available customers
			// 1. Get first 3 orders from customers
			Console.WriteLine("1. First 3 orders from customers:");
			var first3Orders = (from customer in ListGenerators.CustomerList
								from order in customer.Orders ?? new Order[0]
								select new { customer.Name, order.Id, order.Total })
							   .Take(3);
			foreach (var order in first3Orders)
				Console.WriteLine($"   {order.Name}: Order {order.Id} - {order.Total:C}");

			// 2. All but first 2 orders
			Console.WriteLine("\n2. All but first 2 orders:");
			var skipFirst2Orders = (from customer in ListGenerators.CustomerList
									from order in customer.Orders ?? new Order[0]
									select new { customer.Name, order.Id, order.Total })
								   .Skip(2);
			foreach (var order in skipFirst2Orders.Take(3))
				Console.WriteLine($"   {order.Name}: Order {order.Id} - {order.Total:C}");

			// 3. Elements until number less than position
			Console.WriteLine("\n3. Elements until number less than position:");
			int[] partitionNumbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
			var takeWhileGreater = partitionNumbers.TakeWhile((value, index) => value >= index);
			foreach (var num in takeWhileGreater)
				Console.WriteLine($"   {num}");

			// 4. Elements starting from first divisible by 3
			Console.WriteLine("\n4. Elements from first divisible by 3:");
			var skipUntilDivisibleBy3 = partitionNumbers.SkipWhile(n => n % 3 != 0);
			foreach (var num in skipUntilDivisibleBy3)
				Console.WriteLine($"   {num}");

			// 5. Elements from first less than its position
			Console.WriteLine("\n5. Elements from first less than position:");
			var skipUntilLess = partitionNumbers.SkipWhile((value, index) => value >= index);
			foreach (var num in skipUntilLess)
				Console.WriteLine($"   {num}");

			#endregion

			#region LINQ - Quantifiers

			Console.WriteLine("\n=== LINQ - Quantifiers ===");

			// 1. Check if any word contains 'ei' (simulated)
			Console.WriteLine("1. Any word contains 'ei':");
			string[] testWords = { "receive", "believe", "achieve", "apple", "banana" };
			bool hasEI = testWords.Any(w => w.Contains("ei"));
			Console.WriteLine($"   Any word contains 'ei': {hasEI}");

			// 2. Categories with at least one product out of stock
			Console.WriteLine("\n2. Categories with at least one out-of-stock product:");
			var categoriesWithOutOfStock = ListGenerators.ProductList
				.GroupBy(p => p.Category)
				.Where(g => g.Any(p => p.UnitsInStock == 0))
				.Select(g => new { Category = g.Key, Products = g.ToList() });
			foreach (var category in categoriesWithOutOfStock)
				Console.WriteLine($"   {category.Category} ({category.Products.Count} products)");

			// 3. Categories where all products are in stock
			Console.WriteLine("\n3. Categories where all products are in stock:");
			var categoriesAllInStock = ListGenerators.ProductList
				.GroupBy(p => p.Category)
				.Where(g => g.All(p => p.UnitsInStock > 0))
				.Select(g => new { Category = g.Key, Products = g.ToList() });
			foreach (var category in categoriesAllInStock)
				Console.WriteLine($"   {category.Category} ({category.Products.Count} products)");

			#endregion

			Console.WriteLine("\n=== Assignment Complete ===");
			Console.ReadKey();
		}
	}
}
