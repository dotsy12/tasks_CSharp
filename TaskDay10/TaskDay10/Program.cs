using System;
using System.Collections.Generic;

#region Problem 1
/*
Problem:
Implement a sorting algorithm using the SortingAlgorithm<T> class 
for an array of Employee objects based on their salary in ascending order.
*/
public class Employee
{
	public string Name { get; set; }
	public decimal Salary { get; set; }
}

public class SortingAlgorithm<T>
{
	public void Sort(T[] array, Comparison<T> comparison)
	{
		Array.Sort(array, comparison);
	}
}

public static class Problem1Demo
{
	public static void Run()
	{
		var employees = new Employee[]
		{
			new Employee { Name = "Ali", Salary = 3000 },
			new Employee { Name = "Sara", Salary = 2000 },
			new Employee { Name = "Omar", Salary = 4000 }
		};

		var sorter = new SortingAlgorithm<Employee>();
		sorter.Sort(employees, (e1, e2) => e1.Salary.CompareTo(e2.Salary));

		foreach (var emp in employees)
			Console.WriteLine($"{emp.Name} - {emp.Salary}");
	}
}
/*
Question:
What are the benefits of using a generic sorting algorithm over a non-generic one?

Answer:
Generics provide type safety, code reusability, and performance improvements
by avoiding boxing/unboxing. The same algorithm can work for Employee, int,
string, etc. without rewriting the sorting logic.
*/
#endregion

#region Problem 2
/*
Problem:
Modify the SortingTwo<T>.Sort method to dynamically sort integers in descending order 
using a lambda expression.
*/
public class SortingTwo<T>
{
	public void Sort(T[] array, Comparison<T> comparison)
	{
		Array.Sort(array, comparison);
	}
}

public static class Problem2Demo
{
	public static void Run()
	{
		int[] numbers = { 1, 4, 2, 9, 5 };
		var sorter = new SortingTwo<int>();
		sorter.Sort(numbers, (a, b) => b.CompareTo(a));

		Console.WriteLine(string.Join(", ", numbers));
	}
}
/*
Question:
How do lambda expressions improve the readability and flexibility of sorting methods?

Answer:
Lambdas provide inline, concise definitions of sorting rules without creating
separate methods or classes. This makes the code more readable, flexible, 
and closer to the business logic.
*/
#endregion

#region Problem 3
/*
Problem:
Write a comparer function to sort strings based on their length in ascending order 
using SortingTwo<T>.Sort.
*/
public static class Problem3Demo
{
	public static void Run()
	{
		string[] words = { "apple", "kiwi", "banana", "fig" };
		var sorter = new SortingTwo<string>();
		sorter.Sort(words, (a, b) => a.Length.CompareTo(b.Length));

		Console.WriteLine(string.Join(", ", words));
	}
}
/*
Question:
Why is it important to use a dynamic comparer function when sorting objects of various data types?

Answer:
Dynamic comparers allow us to define sorting logic at runtime, making algorithms reusable across
different scenarios without modifying the underlying sorting method.
*/
#endregion

#region Problem 4
/*
Problem:
Add a new class Manager that inherits from Employee and implements IComparable<Manager>.
Update the sorting logic to include Manager objects and compare by Salary.
*/
public class Manager : Employee, IComparable<Manager>
{
	public int CompareTo(Manager other)
	{
		return this.Salary.CompareTo(other.Salary);
	}
}
public static class Problem4Demo
{
	public static void Run()
	{
		var managers = new Manager[]
		{
			new Manager { Name="Ahmed", Salary=7000 },
			new Manager { Name="Mona", Salary=5000 }
		};

		Array.Sort(managers);
		foreach (var m in managers)
			Console.WriteLine($"{m.Name} - {m.Salary}");
	}
}
/*
Question:
How does implementing IComparable<T> in derived classes enable custom sorting?

Answer:
It allows objects to define their natural ordering logic (e.g., by Salary for Manager),
so Array.Sort and other algorithms know how to compare them directly.
*/
#endregion

#region Problem 5
/*
Problem:
Create a delegate Func<T, T, bool> to compare Employee objects based on their Name length
and sort an array of employees.
*/
public static class Problem5Demo
{
	public static void Run()
	{
		Func<Employee, Employee, bool> compareByNameLength =
			(e1, e2) => e1.Name.Length < e2.Name.Length;

		var employees = new[]
		{
			new Employee {Name="Ali", Salary=2000},
			new Employee {Name="Mohammed", Salary=3000}
		};

		Array.Sort(employees, (e1, e2) => e1.Name.Length.CompareTo(e2.Name.Length));
		foreach (var e in employees)
			Console.WriteLine(e.Name);
	}
}
/*
Question:
What is the advantage of using built-in delegates like Func<T, T, TResult> in generic programming?

Answer:
Func reduces boilerplate code for defining delegates, improves readability, 
and allows flexible custom logic without explicitly declaring new delegate types.
*/
#endregion

#region Problem 6
/*
Problem:
Use an anonymous function to sort an integer array in ascending order.
Demonstrate the same logic with a lambda expression.
*/
public static class Problem6Demo
{
	public static void Run()
	{
		int[] arr1 = { 5, 3, 1, 4, 2 };
		Array.Sort(arr1, delegate (int a, int b) { return a.CompareTo(b); });
		Console.WriteLine("Anonymous: " + string.Join(", ", arr1));

		int[] arr2 = { 5, 3, 1, 4, 2 };
		Array.Sort(arr2, (a, b) => a.CompareTo(b));
		Console.WriteLine("Lambda: " + string.Join(", ", arr2));
	}
}
/*
Question:
How does the usage of anonymous functions differ from lambda expressions in terms of readability and efficiency?

Answer:
Anonymous functions are more verbose and harder to read. Lambdas are concise, 
easier to maintain, and compile down to the same IL with better readability.
*/
#endregion

#region Problem 7
/*
Problem:
Enhance the SortingAlgorithm<T> class by implementing a standalone generic method Swap<T> 
and demonstrate swapping elements of an integer array.
*/
public static class Util
{
	public static void Swap<T>(ref T a, ref T b)
	{
		T temp = a;
		a = b;
		b = temp;
	}
}

public static class Problem7Demo
{
	public static void Run()
	{
		int x = 1, y = 2;
		Util.Swap(ref x, ref y);
		Console.WriteLine($"x={x}, y={y}");
	}
}
/*
Question:
Why is the use of generic methods beneficial when creating utility functions like Swap?

Answer:
Generic methods work with any data type without code duplication, 
ensuring type safety and maximizing reusability.
*/
#endregion

// ⚡ باقي الـ Problems (8 → 20) بنفس الشكل هكملهمولك
#region Problem 8
/*
Problem:
Extend SortingTwo<T>.Sort to sort Employee objects first by Salary, 
and in case of ties, by Name using a custom comparer.
*/
public static class Problem8Demo
{
	public static void Run()
	{
		var employees = new[]
		{
			new Employee { Name="Omar", Salary=3000 },
			new Employee { Name="Ali", Salary=3000 },
			new Employee { Name="Sara", Salary=2000 }
		};

		var sorter = new SortingTwo<Employee>();
		sorter.Sort(employees, (e1, e2) =>
		{
			int salaryCompare = e1.Salary.CompareTo(e2.Salary);
			return salaryCompare == 0 ? e1.Name.CompareTo(e2.Name) : salaryCompare;
		});

		foreach (var e in employees)
			Console.WriteLine($"{e.Name} - {e.Salary}");
	}
}
/*
Question:
What are the challenges and benefits of implementing multi-criteria sorting logic in generic methods?

Answer:
Challenges: complexity increases with more criteria, need for careful comparer design.
Benefits: flexibility to define advanced ordering rules while keeping sorting generic and reusable.
*/
#endregion

#region Problem 9
/*
Problem:
Write a method GetDefault that uses default(T) to return the default value of generic types 
and demonstrate its use with value types and reference types.
*/
public static class Problem9Demo
{
	public static T GetDefault<T>()
	{
		return default(T);
	}

	public static void Run()
	{
		int defaultInt = GetDefault<int>(); // 0
		string defaultString = GetDefault<string>(); // null
		Console.WriteLine($"Default int: {defaultInt}, Default string: {defaultString ?? "null"}");
	}
}
/*
Question:
Why is the default(T) keyword crucial in generic programming, and how does it handle value and reference types differently?

Answer:
default(T) provides a safe way to initialize generics: 0 for value types, null for reference types.
It ensures consistency without knowing the type at compile time.
*/
#endregion

#region Problem 10
/*
Problem:
Add a constraint to the SortingAlgorithm<T> class to ensure T implements ICloneable. 
Demonstrate cloning an Employee array before sorting it.
*/
public class SortingAlgorithmClone<T> where T : ICloneable
{
	public void Sort(T[] array, Comparison<T> comparison)
	{
		Array.Sort(array, comparison);
	}
}
public class CloneableEmployee : Employee, ICloneable
{
	public object Clone() => new CloneableEmployee { Name = this.Name, Salary = this.Salary };
}
public static class Problem10Demo
{
	public static void Run()
	{
		var employees = new[]
		{
			new CloneableEmployee {Name="Ali", Salary=3000},
			new CloneableEmployee {Name="Sara", Salary=2000}
		};

		var cloned = (CloneableEmployee[])employees.Clone();
		var sorter = new SortingAlgorithmClone<CloneableEmployee>();
		sorter.Sort(cloned, (a, b) => a.Salary.CompareTo(b.Salary));

		foreach (var e in cloned)
			Console.WriteLine($"{e.Name} - {e.Salary}");
	}
}
/*
Question:
How do constraints in generic programming ensure type safety and improve reliability?

Answer:
Constraints ensure only compatible types are used, preventing runtime errors.
For example, requiring ICloneable guarantees Clone() is available on type T.
*/
#endregion

#region Problem 11
/*
Problem:
Create a delegate that takes a string and returns a string. 
Implement a function that applies this delegate to each element in a list of strings.
*/
public delegate string StringTransformer(string input);

public static class Problem11Demo
{
	public static List<string> Transform(List<string> input, StringTransformer transformer)
	{
		var result = new List<string>();
		foreach (var str in input)
			result.Add(transformer(str));
		return result;
	}

	public static void Run()
	{
		var data = new List<string> { "hello", "world" };
		var upper = Transform(data, s => s.ToUpper());
		Console.WriteLine(string.Join(", ", upper));
	}
}
/*
Question:
What are the benefits of using delegates for string transformations in functional style?

Answer:
Delegates allow passing behavior as parameters, promoting code reusability,
cleaner transformations, and separation of logic from iteration.
*/
#endregion

#region Problem 12
/*
Problem:
Create a delegate that takes two integers and returns an integer. 
Implement a function that takes two integers and a delegate and performs the operation.
*/
public delegate int MathOperation(int a, int b);

public static class Problem12Demo
{
	public static int Calculate(int a, int b, MathOperation op)
	{
		return op(a, b);
	}

	public static void Run()
	{
		Console.WriteLine(Calculate(5, 3, (x, y) => x + y));
		Console.WriteLine(Calculate(5, 3, (x, y) => x - y));
	}
}
/*
Question:
How does the use of delegates promote code reusability and flexibility?

Answer:
It allows defining multiple operations without changing the Calculate method, 
enabling reuse and flexibility for any mathematical logic.
*/
#endregion

#region Problem 13
/*
Problem:
Define a generic delegate that takes T and returns R. 
Transform a list<T> into list<R>.
*/
public delegate R Transformer<T, R>(T item);

public static class Problem13Demo
{
	public static List<R> Transform<T, R>(List<T> input, Transformer<T, R> transformer)
	{
		var result = new List<R>();
		foreach (var item in input)
			result.Add(transformer(item));
		return result;
	}

	public static void Run()
	{
		var numbers = new List<int> { 1, 2, 3 };
		var strings = Transform(numbers, n => n.ToString());
		Console.WriteLine(string.Join(", ", strings));
	}
}
/*
Question:
What are the advantages of using generic delegates in transforming data structures?

Answer:
Generic delegates make transformations type-safe, reusable, and applicable to any type combination.
*/
#endregion

#region Problem 14
/*
Problem:
Use Func<T, TResult> to square integers in a list.
*/
public static class Problem14Demo
{
	public static List<int> ApplySquare(List<int> numbers, Func<int, int> func)
	{
		var result = new List<int>();
		foreach (var n in numbers)
			result.Add(func(n));
		return result;
	}

	public static void Run()
	{
		var nums = new List<int> { 1, 2, 3 };
		var squared = ApplySquare(nums, x => x * x);
		Console.WriteLine(string.Join(", ", squared));
	}
}
/*
Question:
How does Func simplify delegate usage?

Answer:
Func removes the need to define custom delegate types, reducing boilerplate 
and making code more expressive and readable.
*/
#endregion

#region Problem 15
/*
Problem:
Use Action<T> to print each string in a list.
*/
public static class Problem15Demo
{
	public static void ApplyAction(List<string> items, Action<string> action)
	{
		foreach (var item in items)
			action(item);
	}

	public static void Run()
	{
		var list = new List<string> { "one", "two" };
		ApplyAction(list, Console.WriteLine);
	}
}
/*
Question:
Why is Action preferred for void-returning operations?

Answer:
Action<T> represents operations without results, making intent clear and reducing overhead.
*/
#endregion

#region Problem 16
/*
Problem:
Use Predicate<T> to filter even numbers.
*/
public static class Problem16Demo
{
	public static List<int> Filter(List<int> nums, Predicate<int> predicate)
	{
		return nums.FindAll(predicate);
	}

	public static void Run()
	{
		var nums = new List<int> { 1, 2, 3, 4, 6 };
		var evens = Filter(nums, n => n % 2 == 0);
		Console.WriteLine(string.Join(", ", evens));
	}
}
/*
Question:
What role do predicates play in functional programming?

Answer:
Predicates define boolean conditions cleanly, improving clarity when filtering collections.
*/
#endregion
