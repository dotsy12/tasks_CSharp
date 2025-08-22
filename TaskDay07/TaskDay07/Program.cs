using System;

namespace TasksSolution
{
	class Program
	{
		static void Main(string[] args)
		{
			// Run demonstrations here

			// Car constructors
			Car car1 = new Car();
			Car car2 = new Car(1);
			Car car3 = new Car(2, "Toyota");
			Car car4 = new Car(3, "BMW", 50000);
			Console.WriteLine($"{car1.Id}, {car1.Brand}, {car1.Price}");
			Console.WriteLine($"{car2.Id}, {car2.Brand}, {car2.Price}");
			Console.WriteLine($"{car3.Id}, {car3.Brand}, {car3.Price}");
			Console.WriteLine($"{car4.Id}, {car4.Brand}, {car4.Price}");

			// Calculator overloads
			Calculator calc = new Calculator();
			Console.WriteLine(calc.Sum(2, 3));
			Console.WriteLine(calc.Sum(2, 3, 4));
			Console.WriteLine(calc.Sum(2.5, 3.5));

			// Constructor chaining
			Child child = new Child(5, 10, 15);
			Console.WriteLine($"Child: X={child.X}, Y={child.Y}, Z={child.Z}");

			// new vs override
			Child c = new Child(2, 3, 4);
			Console.WriteLine("Child Product (new): " + c.Product());
			Parent p = c;
			Console.WriteLine("Parent Ref Product (override): " + p.Product());

			// ToString()
			Console.WriteLine(p.ToString());
			Console.WriteLine(c.ToString());

			// IShape Rectangle
			IShape rect = new Rectangle(5, 10);
			rect.Draw();
			Console.WriteLine("Area: " + rect.Area);

			// IShape Circle (default method)
			IShape circle = new Circle(5);
			circle.Draw();
			Console.WriteLine("Area: " + circle.Area);
			circle.PrintDetails();

			// IMovable
			IMovable movable = new CarMovable();
			movable.Move();

			// Multiple interfaces
			File file = new File();
			file.Read();
			file.Write();

			// Virtual vs Abstract
			Shape rect2 = new Rectangle2(5, 4);
			rect2.Draw();
			Console.WriteLine("Area: " + rect2.CalculateArea());
		}
	}

	#region Problem01 Car with Constructors
	/*
     * Question: Why does defining a custom constructor suppress the default constructor in C#?
     * Answer: When you define any constructor explicitly, the compiler does not generate
     * the default parameterless constructor automatically. This is because it assumes you want 
     * full control over object initialization.
     */
	class Car
	{
		public int Id { get; set; }
		public string Brand { get; set; }
		public double Price { get; set; }

		public Car()
		{
			Id = 0; Brand = "Unknown"; Price = 0;
		}
		public Car(int id) { Id = id; }
		public Car(int id, string brand) { Id = id; Brand = brand; }
		public Car(int id, string brand, double price) { Id = id; Brand = brand; Price = price; }
	}
	#endregion

	#region Problem02 Calculator with Overloads
	/*
     * Question: How does method overloading improve code readability and reusability?
     * Answer: Method overloading allows using the same method name with different parameters,
     * making the code more intuitive and reducing the need for multiple method names. 
     * It improves readability and promotes reusability.
     */
	class Calculator
	{
		public int Sum(int a, int b) => a + b;
		public int Sum(int a, int b, int c) => a + b + c;
		public double Sum(double a, double b) => a + b;
	}
	#endregion

	#region Problem03 Constructor Chaining
	/*
     * Question: What is the purpose of constructor chaining in inheritance?
     * Answer: Constructor chaining ensures that base class initialization logic runs before
     * the derived class constructor executes. It helps reuse code and maintain consistent initialization.
     */
	class Parent
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Parent(int x, int y)
		{
			X = x;
			Y = y;
		}

		public virtual int Product() => X * Y;

		public override string ToString() => $"({X}, {Y})";
	}

	class Child : Parent
	{
		public int Z { get; set; }

		public Child(int x, int y, int z) : base(x, y)
		{
			Z = z;
		}

		public new int Product() => X * Y * Z; // new
		public override int Product() => (X + Y) * Z; // override

		public override string ToString() => $"({X}, {Y}, {Z})";
	}
	#endregion

	#region Problem04 new vs override
	/*
     * Question: How does new differ from override in method overriding?
     * Answer: "new" hides the base method, so which method is called depends on the reference type.
     * "override" replaces the base method, so the derived method is called even when accessed by a base reference.
     */
	// (Implemented inside Child class)
	#endregion

	#region Problem05 ToString Override
	/*
     * Question: Why is ToString() often overridden in custom classes?
     * Answer: ToString() provides a human-readable string representation of an object,
     * useful for debugging, logging, or displaying object info meaningfully.
     */
	// (Implemented in Parent and Child classes)
	#endregion

	#region Problem06 IShape Interface
	/*
     * Question: Why can't you create an instance of an interface directly?
     * Answer: Interfaces only define a contract (methods/properties) but do not contain
     * implementation. Therefore, you must use a class that implements the interface.
     */
	interface IShape
	{
		double Area { get; }
		void Draw();

		void PrintDetails()
		{
			Console.WriteLine("This is a shape with area: " + Area);
		}
	}

	class Rectangle : IShape
	{
		public double Width { get; set; }
		public double Height { get; set; }
		public double Area => Width * Height;

		public Rectangle(double w, double h)
		{
			Width = w; Height = h;
		}

		public void Draw() => Console.WriteLine("Drawing Rectangle");
	}
	#endregion

	#region Problem07 Default Implementation in Interface
	/*
     * Question: What are the benefits of default implementations in interfaces introduced in C# 8.0?
     * Answer: Default implementations allow adding new methods to interfaces without breaking 
     * existing implementations. They reduce the need for abstract base classes and provide flexibility.
     */
	class Circle : IShape
	{
		public double Radius { get; set; }
		public double Area => Math.PI * Radius * Radius;

		public Circle(double r) { Radius = r; }

		public void Draw() => Console.WriteLine("Drawing Circle");
	}
	#endregion

	#region Problem08 IMovable Interface
	/*
     * Question: Why is it useful to use an interface reference to access implementing class methods?
     * Answer: Using an interface reference enables polymorphism, allowing different classes 
     * to be treated uniformly if they implement the same interface. It improves flexibility and scalability.
     */
	interface IMovable
	{
		void Move();
	}

	class CarMovable : IMovable
	{
		public void Move() => Console.WriteLine("Car is moving...");
	}
	#endregion

	#region Problem09 Multiple Interfaces
	/*
     * Question: How does C# overcome the limitation of single inheritance with interfaces?
     * Answer: A class can implement multiple interfaces, allowing it to inherit behavior 
     * from multiple sources. This achieves multiple inheritance of type safely.
     */
	interface IReadable { void Read(); }
	interface IWritable { void Write(); }

	class File : IReadable, IWritable
	{
		public void Read() => Console.WriteLine("Reading file...");
		public void Write() => Console.WriteLine("Writing file...");
	}
	#endregion

	#region Problem10 Virtual vs Abstract
	/*
     * Question: What is the difference between a virtual method and an abstract method in C#?
     * Answer: A virtual method provides a default implementation that derived classes may override.
     * An abstract method has no implementation and must be overridden by derived classes.
     */
	abstract class Shape
	{
		public virtual void Draw() => Console.WriteLine("Drawing Shape");
		public abstract double CalculateArea();
	}

	class Rectangle2 : Shape
	{
		public double Width { get; set; }
		public double Height { get; set; }

		public Rectangle2(double w, double h)
		{
			Width = w; Height = h;
		}

		public override void Draw() => Console.WriteLine("Drawing Rectangle2");

		public override double CalculateArea() => Width * Height;
	}
	#endregion

	#region Part02
	/*
     * Q1: What is the difference between class and struct in C#?
     * - Class: Reference type, stored on heap, supports inheritance, garbage-collected, default null.
     * - Struct: Value type, stored on stack, cannot inherit from other structs or classes (only interfaces),
     *           lightweight, best for small data structures.
     *
     * Q2: If inheritance is relation between classes clarify other relations between classes:
     * - Association: A general "uses" relationship (e.g., Student has an Address).
     * - Aggregation: "Has-A" relationship with weak ownership (e.g., Library has Books).
     * - Composition: Strong "Has-A" relationship with lifetime dependency (e.g., House has Rooms).
     * - Dependency: A "uses" relationship temporarily (e.g., Service depends on Logger).
     */
	#endregion
}
