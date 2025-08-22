using System;
using System.Collections.Generic;

namespace Assignment
{
	class Program
	{
		static void Main(string[] args)
		{
			// Problem 1: IVehicle Interface
			IVehicle v1 = new Car();
			IVehicle v2 = new Bike();
			v1.StartEngine(); v1.StopEngine();
			v2.StartEngine(); v2.StopEngine();

			// Problem 2: Abstract Shape
			Shape s1 = new Rectangle(5, 10);
			Shape s2 = new Circle(4);
			s1.Display(); Console.WriteLine($"Area: {s1.GetArea()}");
			s2.Display(); Console.WriteLine($"Area: {s2.GetArea()}");

			// Problem 3: Product Sorting
			Product[] products = {
				new Product{Id=1, Name="Laptop", Price=1500},
				new Product{Id=2, Name="Phone", Price=800},
				new Product{Id=3, Name="Tablet", Price=1000}
			};
			Array.Sort(products);
			foreach (var p in products) Console.WriteLine($"{p.Name} - {p.Price}");

			// Problem 4: Copy Constructor
			Student s = new Student(1, "Ali", 90);
			Student copy = new Student(s); // deep copy
			copy.Name = "Changed";
			Console.WriteLine($"Original: {s.Name}, Copy: {copy.Name}");

			// Problem 5: Explicit Interface
			Robot robot = new Robot();
			robot.Walk(); // class method
			((IWalkable)robot).Walk(); // explicit interface method

			// Problem 6: Struct Account
			Account acc = new Account(1, "Ali", 2000);
			Console.WriteLine($"{acc.AccountId} - {acc.AccountHolder} - {acc.Balance}");

			// Problem 7: ILogger
			ILogger logger = new ConsoleLogger();
			logger.Log();

			// Problem 8: Book constructors
			Book b1 = new Book();
			Book b2 = new Book("C# Guide");
			Book b3 = new Book("Java", "James");
			Console.WriteLine($"{b1.Title}, {b2.Title}, {b3.Title}-{b3.Author}");

			// Part02 - Shape Series
			Console.WriteLine("Square Series:");
			PrintTenShapes(new SquareSeries());
			Console.WriteLine("Circle Series:");
			PrintTenShapes(new CircleSeries());

			// Part02 - Sorting Shapes
			ShapeSort[] shapes = {
				new ShapeSort{Name="Square", Area=25},
				new ShapeSort{Name="Circle", Area=78.5},
				new ShapeSort{Name="Rectangle", Area=40}
			};
			Array.Sort(shapes);
			foreach (var sh in shapes) Console.WriteLine($"{sh.Name}: {sh.Area}");

			// Part02 - GeometricShape
			GeometricShape g1 = new Triangle(3, 4);
			GeometricShape g2 = new RectangleGeo(5, 6);
			Console.WriteLine($"Triangle area: {g1.CalculateArea()}, Perimeter: {g1.Perimeter}");
			Console.WriteLine($"Rectangle area: {g2.CalculateArea()}, Perimeter: {g2.Perimeter}");

			// Part02 - SelectionSort
			int[] nums = { 40, 10, 30, 20 };
			SelectionSort(nums);
			Console.WriteLine("Sorted: " + string.Join(", ", nums));

			// Part02 - Factory
			var factoryRect = ShapeFactory.CreateShape("rectangle", 4, 5);
			var factoryTri = ShapeFactory.CreateShape("triangle", 3, 6);
			Console.WriteLine($"Factory Rectangle area: {factoryRect.CalculateArea()}");
			Console.WriteLine($"Factory Triangle area: {factoryTri.CalculateArea()}");

			// Operator Overloading
			Complex c1 = new Complex(2, 3);
			Complex c2 = new Complex(1, 4);
			Complex c3 = c1 + c2;
			Console.WriteLine($"Complex result: {c3}");
		}

		// Helper for Part02
		static void PrintTenShapes(IShapeSeries series)
		{
			series.ResetSeries();
			for (int i = 0; i < 10; i++)
			{
				series.GetNextArea();
				Console.WriteLine(series.CurrentShapeArea);
			}
		}
	}

	#region Problem01 IVehicle Interface
	/*
     * Question: Why is it better to code against an interface rather than a concrete class?
     * Answer: Because it increases flexibility, supports polymorphism, and allows swapping
     * implementations without changing client code.
     */
	interface IVehicle { void StartEngine(); void StopEngine(); }
	class Car : IVehicle
	{
		public void StartEngine() => Console.WriteLine("Car engine started.");
		public void StopEngine() => Console.WriteLine("Car engine stopped.");
	}
	class Bike : IVehicle
	{
		public void StartEngine() => Console.WriteLine("Bike engine started.");
		public void StopEngine() => Console.WriteLine("Bike engine stopped.");
	}
	#endregion

	#region Problem02 Abstract Shape
	/*
     * Question: When should you prefer an abstract class over an interface?
     * Answer: When you want to provide shared implementation and state along with abstract members,
     * or when all derived classes are closely related.
     */
	abstract class Shape
	{
		public abstract double GetArea();
		public void Display() => Console.WriteLine("Displaying shape...");
	}
	class Rectangle : Shape
	{
		double Width, Height;
		public Rectangle(double w, double h) { Width = w; Height = h; }
		public override double GetArea() => Width * Height;
	}
	class Circle : Shape
	{
		double Radius;
		public Circle(double r) { Radius = r; }
		public override double GetArea() => Math.PI * Radius * Radius;
	}
	#endregion

	#region Problem03 Product Sorting
	/*
     * Question: How does implementing IComparable improve flexibility in sorting?
     * Answer: It allows custom sorting logic to be defined in the class itself,
     * enabling Array.Sort or List.Sort to sort by any chosen property.
     */
	class Product : IComparable<Product>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public int CompareTo(Product other) => this.Price.CompareTo(other.Price);
	}
	#endregion

	#region Problem04 Student Copy Constructor
	/*
     * Question: What is the primary purpose of a copy constructor in C#?
     * Answer: To create a new object as a copy of an existing object, ensuring independent data (deep copy).
     */
	class Student
	{
		public int Id;
		public string Name;
		public int Grade;
		public Student(int id, string name, int grade) { Id = id; Name = name; Grade = grade; }
		public Student(Student other)
		{
			Id = other.Id;
			Name = string.Copy(other.Name);
			Grade = other.Grade;
		}
	}
	#endregion

	#region Problem05 Explicit Interface
	/*
     * Question: How does explicit interface implementation help in resolving naming conflicts?
     * Answer: It allows implementing interface methods separately from class methods
     * when both have the same signature, avoiding ambiguity.
     */
	interface IWalkable { void Walk(); }
	class Robot : IWalkable
	{
		public void Walk() => Console.WriteLine("Robot walking (class method).");
		void IWalkable.Walk() => Console.WriteLine("Robot walking (interface method).");
	}
	#endregion

	#region Problem06 Struct Account
	/*
     * Q1: What is the key difference between encapsulation in structs and classes?
     * A: Both support encapsulation, but structs are value types stored on stack
     *    and cannot have default parameterless constructors.
     *
     * Q2: What is abstraction as a guideline, and what’s its relation with encapsulation?
     * A: Abstraction = exposing only essentials, hiding details.
     *    Encapsulation = the mechanism that achieves abstraction by restricting direct access.
     */
	struct Account
	{
		private int accountId;
		private string accountHolder;
		private double balance;
		public int AccountId { get => accountId; set => accountId = value; }
		public string AccountHolder { get => accountHolder; set => accountHolder = value; }
		public double Balance { get => balance; set => balance = value; }
		public Account(int id, string holder, double bal) { accountId = id; accountHolder = holder; balance = bal; }
	}
	#endregion

	#region Problem07 ILogger
	/*
     * Question: How do default interface implementations affect backward compatibility in C#?
     * Answer: They allow adding new methods to interfaces without breaking existing
     * implementations, improving backward compatibility.
     */
	interface ILogger { void Log() => Console.WriteLine("Default logging..."); }
	class ConsoleLogger : ILogger
	{
		public void Log() => Console.WriteLine("Console Logger: Logging...");
	}
	#endregion

	#region Problem08 Book Constructors
	/*
     * Question: How does constructor overloading improve class usability?
     * Answer: It gives flexibility to initialize objects in different ways,
     * making the class easier and more versatile to use.
     */
	class Book
	{
		public string Title { get; set; }
		public string Author { get; set; }
		public Book() { Title = "Unknown"; Author = "Unknown"; }
		public Book(string title) { Title = title; Author = "Unknown"; }
		public Book(string title, string author) { Title = title; Author = author; }
	}
	#endregion

	#region Part02 Shape Series
	interface IShapeSeries
	{
		int CurrentShapeArea { get; set; }
		void GetNextArea();
		void ResetSeries();
	}
	class SquareSeries : IShapeSeries
	{
		int side = 0;
		public int CurrentShapeArea { get; set; }
		public void GetNextArea() { side++; CurrentShapeArea = side * side; }
		public void ResetSeries() { side = 0; CurrentShapeArea = 0; }
	}
	class CircleSeries : IShapeSeries
	{
		int radius = 0;
		public int CurrentShapeArea { get; set; }
		public void GetNextArea() { radius++; CurrentShapeArea = (int)(Math.PI * radius * radius); }
		public void ResetSeries() { radius = 0; CurrentShapeArea = 0; }
	}
	#endregion

	#region Part02 Sorting Shapes
	class ShapeSort : IComparable<ShapeSort>
	{
		public string Name { get; set; }
		public double Area { get; set; }
		public int CompareTo(ShapeSort other) => Area.CompareTo(other.Area);
	}
	#endregion

	#region Part02 GeometricShape
	abstract class GeometricShape
	{
		public double Dimension1 { get; set; }
		public double Dimension2 { get; set; }
		public abstract double CalculateArea();
		public abstract double Perimeter { get; }
	}
	class Triangle : GeometricShape
	{
		public Triangle(double b, double h) { Dimension1 = b; Dimension2 = h; }
		public override double CalculateArea() => 0.5 * Dimension1 * Dimension2;
		public override double Perimeter => Dimension1 + Dimension2 + Math.Sqrt(Dimension1 * Dimension1 + Dimension2 * Dimension2);
	}
	class RectangleGeo : GeometricShape
	{
		public RectangleGeo(double w, double h) { Dimension1 = w; Dimension2 = h; }
		public override double CalculateArea() => Dimension1 * Dimension2;
		public override double Perimeter => 2 * (Dimension1 + Dimension2);
	}
	#endregion

	#region Part02 SelectionSort
	public static void SelectionSort(int[] numbers)
	{
		for (int i = 0; i < numbers.Length - 1; i++)
		{
			int minIndex = i;
			for (int j = i + 1; j < numbers.Length; j++)
			{
				if (numbers[j] < numbers[minIndex]) minIndex = j;
			}
			int temp = numbers[minIndex];
			numbers[minIndex] = numbers[i];
			numbers[i] = temp;
		}
	}
	#endregion

	#region Part02 Factory Pattern
	class ShapeFactory
	{
		public static GeometricShape CreateShape(string shapeType, double d1, double d2)
		{
			switch (shapeType.ToLower())
			{
				case "rectangle": return new RectangleGeo(d1, d2);
				case "triangle": return new Triangle(d1, d2);
				default: throw new ArgumentException("Unknown shape");
			}
		}
	}
	#endregion

	#region Operator Overloading
	class Complex
	{
		public int Real, Imag;
		public Complex(int r, int i) { Real = r; Imag = i; }
		public static Complex operator +(Complex c1, Complex c2) => new Complex(c1.Real + c2.Real, c1.Imag + c2.Imag);
		public override string ToString() => $"{Real} + {Imag}i";
	}
	#endregion
}
