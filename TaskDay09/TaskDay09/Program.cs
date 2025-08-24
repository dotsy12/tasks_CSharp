using System;

namespace Assignment2
{
	class Program
	{
		static void Main(string[] args)
		{
			// Problem 1
			Person p1 = new Person { Name = "Ali", Department = "HR" };
			Person p2 = new Person { Name = "Omar", Department = "IT" };
			Console.WriteLine(p1);
			Console.WriteLine(p2);

			// Problem 2
			Child c = new Child { Salary = 5000 };
			c.DisplaySalary();

			// Problem 3
			double peri = Utility.CalculatePerimeter(5, 10);
			Console.WriteLine($"Perimeter: {peri}");

			// Problem 4
			ComplexNumber c1 = new ComplexNumber(2, 3);
			ComplexNumber c2 = new ComplexNumber(1, 4);
			ComplexNumber c3 = c1 * c2;
			Console.WriteLine($"Multiplication: {c3}");

			// Problem 5
			Console.WriteLine($"Enum default size: {sizeof(int)} bytes");
			Console.WriteLine($"Enum with byte size: {sizeof(byte)} bytes");

			// Problem 6
			Console.WriteLine($"30C in F = {Utility.ConvertToFahrenheit(30)}");
			Console.WriteLine($"86F in C = {Utility.ConvertToCelsius(86)}");

			// Problem 7
			if (Enum.TryParse("A", out Grades g))
				Console.WriteLine($"Parsed grade: {g}");
			else
				Console.WriteLine("Invalid input");

			// Problem 8
			Employee e1 = new Employee { Id = 1, Name = "Ali" };
			Employee e2 = new Employee { Id = 2, Name = "Omar" };
			Employee[] employees = { e1, e2 };
			int idx = Helper2<Employee>.SearchArray(employees, new Employee { Id = 1, Name = "Ali" });
			Console.WriteLine($"Found at index: {idx}");

			// Problem 9
			Console.WriteLine($"Max int: {Helper.Max(5, 8)}");
			Console.WriteLine($"Max double: {Helper.Max(5.5, 2.3)}");
			Console.WriteLine($"Max string: {Helper.Max("Ali", "Omar")}");

			// Problem 10
			int[] nums = { 1, 2, 3, 2 };
			Helper2<int>.ReplaceArray(nums, 2, 99);
			Console.WriteLine(string.Join(", ", nums));

			string[] names = { "Ali", "Omar", "Ali" };
			Helper2<string>.ReplaceArray(names, "Ali", "Samir");
			Console.WriteLine(string.Join(", ", names));

			// Problem 11
			Rectangle r1 = new Rectangle { Length = 4, Width = 5 };
			Rectangle r2 = new Rectangle { Length = 7, Width = 2 };
			Console.WriteLine($"Before Swap: r1={r1}, r2={r2}");
			RectangleHelper.Swap(ref r1, ref r2);
			Console.WriteLine($"After Swap: r1={r1}, r2={r2}");

			// Problem 12
			Department d1 = new Department { DeptName = "HR" };
			Department d2 = new Department { DeptName = "IT" };
			Employee e3 = new Employee { Id = 3, Name = "Sara", Dept = d1 };
			Employee e4 = new Employee { Id = 4, Name = "Nora", Dept = d2 };
			Employee[] emps = { e3, e4 };
			int deptIndex = Helper2<Employee>.SearchArray(emps, new Employee { Id = 0, Name = "", Dept = new Department { DeptName = "IT" } });
			Console.WriteLine($"Found Dept Employee at index: {deptIndex}");

			// Problem 13
			CircleStruct cs1 = new CircleStruct { Radius = 5, Color = "Red" };
			CircleStruct cs2 = new CircleStruct { Radius = 5, Color = "Red" };
			Console.WriteLine($"Struct Equals: {cs1.Equals(cs2)}");
			Console.WriteLine($"Struct == : {cs1 == cs2}");

			CircleClass cc1 = new CircleClass { Radius = 5, Color = "Red" };
			CircleClass cc2 = new CircleClass { Radius = 5, Color = "Red" };
			Console.WriteLine($"Class Equals: {cc1.Equals(cc2)}");
			Console.WriteLine($"Class == : {cc1 == cc2}");
		}
	}

	#region Problem01 Person with Department
	/*
     * Question: What is the purpose of the virtual keyword when used with properties?
     * Answer: It allows derived classes to override the property’s implementation,
     * enabling polymorphism with properties.
     */
	class Person
	{
		public string Name { get; set; }
		public virtual string Department { get; set; }
		public override string ToString() => $"{Name} - {Department}";
	}
	#endregion

	#region Problem02 Child with sealed Salary
	/*
     * Question: Why can’t you override a sealed property or method?
     * Answer: Because sealed prevents further overriding to ensure class stability and
     * preserve behavior from being changed in derived classes.
     */
	class Parent
	{
		public virtual int Salary { get; set; }
	}
	class Child : Parent
	{
		public sealed override int Salary { get; set; }
		public void DisplaySalary() => Console.WriteLine($"Salary: {Salary}");
	}
	#endregion

	#region Problem03 Utility Static Perimeter
	/*
     * Question: What is the key difference between static and object members?
     * Answer: Static members belong to the class itself and are shared across all instances,
     * while object members belong to each instance individually.
     */
	static class Utility
	{
		public static double CalculatePerimeter(double l, double w) => 2 * (l + w);
		public static double ConvertToFahrenheit(double c) => (c * 9 / 5) + 32;
		public static double ConvertToCelsius(double f) => (f - 32) * 5 / 9;
	}
	#endregion

	#region Problem04 ComplexNumber Multiplication
	/*
     * Question: Can you overload all operators in C#? Explain why or why not.
     * Answer: No. Some operators (like &&, ||, =) cannot be overloaded.
     * Only arithmetic, comparison, and bitwise operators can be overloaded.
     */
	class ComplexNumber
	{
		public int Real, Imag;
		public ComplexNumber(int r, int i) { Real = r; Imag = i; }
		public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
			=> new ComplexNumber(a.Real * b.Real - a.Imag * b.Imag, a.Real * b.Imag + a.Imag * b.Real);
		public override string ToString() => $"{Real} + {Imag}i";
	}
	#endregion

	#region Problem05 Gender enum with byte
	/*
     * Question: When should you consider changing the underlying type of an enum?
     * Answer: When memory efficiency is important, or when integrating with external
     * systems that require a specific type size.
     */
	enum Gender : byte { Male, Female }
	#endregion

	#region Problem06 Static Temperature Conversion
	/*
     * Question: Why can't a static class have instance constructors?
     * Answer: Because static classes cannot be instantiated,
     * and therefore don’t need instance constructors.
     */
	#endregion

	#region Problem07 Enum.TryParse
	/*
     * Question: What are the advantages of using Enum.TryParse over direct parsing with int.Parse?
     * Answer: It prevents exceptions, handles invalid inputs safely, and improves code reliability.
     */
	enum Grades { A, B, C, D, F }
	#endregion

	#region Problem08 Employee Equals
	/*
     * Question: What is the difference between overriding Equals and == for object comparison in C# struct and class?
     * Answer: Equals can be overridden for logical equality checks, while == must be explicitly
     * overloaded. By default, == checks reference equality for classes, but value equality for structs.
     */
	class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Department Dept { get; set; }
		public override bool Equals(object obj)
		{
			if (obj is Employee e)
				return Id == e.Id && Name == e.Name && Equals(Dept, e.Dept);
			return false;
		}
		public override int GetHashCode() => (Id, Name, Dept).GetHashCode();
	}
	#endregion

	#region Problem09 Generic Max
	/*
     * Question: Can generics be constrained to specific types in C#? Provide an example.
     * Answer: Yes, using constraints like "where T : struct", "where T : class", or "where T : IComparable".
     * Example: public static T Max<T>(T a, T b) where T : IComparable<T>
     */
	class Helper
	{
		public static T Max<T>(T a, T b) where T : IComparable<T> => a.CompareTo(b) > 0 ? a : b;
	}
	#endregion

	#region Problem10 Helper2 ReplaceArray
	/*
     * Question: What are the key differences between generic methods and generic classes?
     * Answer: Generic methods define type parameters only for the method scope,
     * while generic classes define type parameters that apply to all members of the class.
     */
	class Helper2<T>
	{
		public static int SearchArray(T[] arr, T val)
		{
			for (int i = 0; i < arr.Length; i++)
				if (arr[i].Equals(val)) return i;
			return -1;
		}
		public static void ReplaceArray(T[] arr, T oldVal, T newVal)
		{
			for (int i = 0; i < arr.Length; i++)
				if (arr[i].Equals(oldVal)) arr[i] = newVal;
		}
	}
	#endregion

	#region Problem11 Rectangle Swap
	/*
     * Question: Why might using a generic swap method be preferable to implementing custom methods for each type?
     * Answer: Because it avoids code duplication and works for any type, improving reusability and maintainability.
     */
	struct Rectangle
	{
		public int Length, Width;
		public override string ToString() => $"({Length}, {Width})";
	}
	static class RectangleHelper
	{
		public static void Swap(ref Rectangle r1, ref Rectangle r2)
		{
			Rectangle temp = r1;
			r1 = r2;
			r2 = temp;
		}
	}
	#endregion

	#region Problem12 Department in Employee
	/*
     * Question: How can overriding Equals for the Department class improve the accuracy of searches?
     * Answer: It ensures two departments with the same values are treated as equal,
     * allowing correct comparisons during searches.
     */
	class Department
	{
		public string DeptName { get; set; }
		public override bool Equals(object obj) => obj is Department d && DeptName == d.DeptName;
		public override int GetHashCode() => DeptName.GetHashCode();
	}
	#endregion

	#region Problem13 Circle struct vs class
	/*
     * Question: Why is == not implemented by default for structs?
     * Answer: To avoid performance issues and because value comparison can be expensive.
     * Instead, Equals is provided and can be overridden.
     */
	struct CircleStruct
	{
		public int Radius;
		public string Color;
		public static bool operator ==(CircleStruct a, CircleStruct b) => a.Equals(b);
		public static bool operator !=(CircleStruct a, CircleStruct b) => !a.Equals(b);
		public override bool Equals(object obj) => obj is CircleStruct c && Radius == c.Radius && Color == c.Color;
		public override int GetHashCode() => (Radius, Color).GetHashCode();
	}
	class CircleClass
	{
		public int Radius;
		public string Color;
		public override bool Equals(object obj) => obj is CircleClass c && Radius == c.Radius && Color == c.Color;
		public override int GetHashCode() => (Radius, Color).GetHashCode();
	}
	#endregion
}
#region Question: Generalization using Generics
/*
 * Question: What we mean by Generalization concept using Generics?
 * Answer: 
 * Generalization using Generics means writing reusable code that can work 
 * with different data types without duplicating the logic. 
 * Instead of writing separate methods or classes for int, string, double, etc., 
 * we define one generic method/class that works for all types. 
 * Example: A generic "List<T>" can store integers, strings, or custom objects.
 */
#endregion

#region Question: Hierarchy Design in Real Business
/*
 * Question: What we mean by hierarchy design in real business?
 * Answer: 
 * Hierarchy design in real business refers to modeling the real-world 
 * organizational structure (like CEO → Manager → Employee). 
 * In software design, it is represented through inheritance, 
 * where base classes define common properties/behaviors and 
 * derived classes extend them with specialized functionality.
 * Example: A base class "Employee" with derived classes "Manager" and "Developer".
 */
#endregion
#region Question: Event Driven Programming
/*
 * Question: What is Event Driven Programming?
 * Answer:
 * Event Driven Programming (EDP) is a programming paradigm 
 * where the flow of the program is determined by events 
 * such as user actions (mouse clicks, key presses), 
 * sensor outputs, or messages from other programs.
 * 
 * In C#, this is implemented using "events" and "delegates".
 * For example, when a button is clicked, an event is raised 
 * and the corresponding event handler (method) executes.
 * 
 * Key Benefits:
 * - Makes programs interactive and responsive.
 * - Separates event generation from event handling (loose coupling).
 * - Used heavily in GUI applications, games, and asynchronous systems.
 */
#endregion
