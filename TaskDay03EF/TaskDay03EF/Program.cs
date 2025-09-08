using System;
using System.Linq;
using TaskDay03EF.Data;
using TaskDay03EF.Models;

namespace TaskDay03EF
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using var context = new AppDbContext();

			
			context.Database.EnsureCreated();

	
			var project1 = new project
			{
				cost = 1000000
			
			};

			context.Projects.Add(project1);
			context.SaveChanges();

			
			var project2 = new project
			{
				name = "Custom Project",
				cost = 2500000
		
			};

			context.Projects.Add(project2);
			context.SaveChanges();

		
			var projects = context.Projects.ToList();
			foreach (var project in projects)
			{
				Console.WriteLine($"Project: ID={project.id}, Name={project.name}, Cost={project.cost:C}");
			}
		}
	}
}
