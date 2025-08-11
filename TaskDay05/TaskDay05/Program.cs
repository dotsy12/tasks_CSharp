using System;

namespace TaskDay05
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("All tasks implemented. Uncomment specific methods in Main to test them.");
		}

		// ------------------ Part 01 ------------------

		#region Part01_Problem1
		/*
         Problem: Write a program that:
         - Reads two integers from the user and divides them.
         - Catches DivideByZeroException and displays an appropriate message.
         - Uses a finally block to print "Operation complete" regardless of success or failure.
        */
		static void DivideNumbers()
		{
			try
			{
				Console.Write("Enter first number: ");
				int x = int.Parse(Console.ReadLine());
				Console.Write("Enter second number: ");
				int y = int.Parse(Console.ReadLine());

				int result = x / y;
				Console.WriteLine($"Result: {result}");
			}
			catch (DivideByZeroException)
			{
				Console.WriteLine("Error: Cannot divide by zero.");
			}
			finally
			{
				Console.WriteLine("Operation complete");
			}
		}

		// Question: What is the purpose of the finally block?
		// Answer: The finally block ensures that a set of statements is always executed,
		// regardless of whether an exception is thrown or not.
		#endregion

		#region Part01_Problem2
		/*
         Problem: Modify the TestDefensiveCode method in demo to:
         - Accept only positive integers for both X and Y.
         - Ensure Y is greater than 1.
        */
		static void TestDefensiveCode()
		{
			int x, y;
			while (true)
			{
				Console.Write("Enter a positive integer for X: ");
				if (int.TryParse(Console.ReadLine(), out x) && x > 0)
					break;
				Console.WriteLine("Invalid input. Try again.");
			}
			while (true)
			{
				Console.Write("Enter a positive integer greater than 1 for Y: ");
				if (int.TryParse(Console.ReadLine(), out y) && y > 1)
					break;
				Console.WriteLine("Invalid input. Try again.");
			}
			Console.WriteLine($"X = {x}, Y = {y}");
		}

		// Question: How does int.TryParse() improve program robustness compared to int.Parse()?
		// Answer: int.TryParse() prevents exceptions by returning false when parsing fails,
		// allowing validation without crashing the program.
		#endregion

		#region Part01_Problem3
		/*
         Problem: Nullable integer with ?? operator and HasValue/Value properties.
        */
		static void NullableIntegerDemo()
		{
			int? number = null;
			int defaultValue = number ?? 10;
			Console.WriteLine($"Number: {number}, Default Value: {defaultValue}");

			if (number.HasValue)
				Console.WriteLine($"Value: {number.Value}");
			else
				Console.WriteLine("Number is null.");
		}

		// Question: What exception occurs when trying to access Value on a null Nullable<T>?
		// Answer: InvalidOperationException.
		#endregion

		#region Part01_Problem4
		/*
         Problem: Handle IndexOutOfRangeException in a 1D array.
        */
		static void ArrayOutOfBoundsDemo()
		{
			int[] arr = new int[5] { 1, 2, 3, 4, 5 };
			try
			{
				Console.WriteLine(arr[10]);
			}
			catch (IndexOutOfRangeException)
			{
				Console.WriteLine("Error: Index out of range.");
			}
		}

		// Question: Why is it necessary to check array bounds before accessing elements?
		// Answer: To avoid accessing memory outside the array limits, which throws an exception.
		#endregion

		#region Part01_Problem5
		/*
         Problem: 3x3 array sum of rows and columns.
        */
		static void SumRowsAndColumns()
		{
			int[,] matrix = new int[3, 3];
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
				{
					Console.Write($"Enter value for [{i},{j}]: ");
					matrix[i, j] = int.Parse(Console.ReadLine());
				}

			for (int i = 0; i < 3; i++)
			{
				int rowSum = 0;
				for (int j = 0; j < 3; j++)
					rowSum += matrix[i, j];
				Console.WriteLine($"Sum of row {i}: {rowSum}");
			}

			for (int j = 0; j < 3; j++)
			{
				int colSum = 0;
				for (int i = 0; i < 3; i++)
					colSum += matrix[i, j];
				Console.WriteLine($"Sum of column {j}: {colSum}");
			}
		}

		// Question: How is the GetLength(dimension) method used in multi-dimensional arrays?
		// Answer: GetLength(dimension) returns the size of the array in the specified dimension.
		#endregion

		#region Part01_Problem6
		/*
         Problem: Jagged array with user input.
        */
		static void JaggedArrayDemo()
		{
			int[][] jagged = new int[3][];
			for (int i = 0; i < jagged.Length; i++)
			{
				Console.Write($"Enter size for row {i}: ");
				int size = int.Parse(Console.ReadLine());
				jagged[i] = new int[size];
				for (int j = 0; j < size; j++)
				{
					Console.Write($"Enter value for [{i},{j}]: ");
					jagged[i][j] = int.Parse(Console.ReadLine());
				}
			}
			foreach (var row in jagged)
				Console.WriteLine(string.Join(" ", row));
		}

		// Question: How does the memory allocation differ between jagged arrays and rectangular arrays?
		// Answer: Jagged arrays store each row as a separate array in memory, allowing different lengths.
		#endregion

		#region Part01_Problem7
		/*
         Problem: Nullable reference types and null-forgiveness operator.
        */
		static void NullableReferenceDemo()
		{
			string? name = null;
			Console.Write("Enter name (leave empty for null): ");
			string input = Console.ReadLine();
			if (!string.IsNullOrEmpty(input))
				name = input;
			Console.WriteLine(name!);
		}

		// Question: What is the purpose of nullable reference types in C#?
		// Answer: They help detect potential null reference errors at compile time.
		#endregion

		#region Part01_Problem8
		/*
         Problem: Boxing and unboxing.
        */
		static void BoxingUnboxingDemo()
		{
			int num = 10;
			object obj = num; // boxing
			try
			{
				int unboxed = (int)obj; // unboxing
				Console.WriteLine($"Unboxed: {unboxed}");
			}
			catch (InvalidCastException)
			{
				Console.WriteLine("Invalid cast during unboxing.");
			}
		}

		// Question: What is the performance impact of boxing and unboxing in C#?
		// Answer: They are relatively costly operations involving memory allocation and type conversion.
		#endregion

		#region Part01_Problem9
		/*
         Problem: Method with out parameters.
        */
		static void SumAndMultiply(int a, int b, out int sum, out int product)
		{
			sum = a + b;
			product = a * b;
		}

		// Question: Why must out parameters be initialized inside the method?
		// Answer: Because they must be assigned a value before the method returns.
		#endregion

		#region Part01_Problem10
		/*
         Problem: Method with optional parameter and named parameters.
        */
		static void PrintMessage(string message, int times = 5)
		{
			for (int i = 0; i < times; i++)
				Console.WriteLine(message);
		}

		// Question: Why must optional parameters always appear at the end of a method's parameter list?
		// Answer: To avoid ambiguity when calling the method.
		#endregion

		#region Part01_Problem11
		/*
         Problem: Nullable array and null propagation.
        */
		static void NullableArrayDemo()
		{
			int[]? numbers = null;
			Console.WriteLine(numbers?.Length ?? 0);
		}

		// Question: How does the null propagation operator prevent NullReferenceException?
		// Answer: It stops evaluation if the object is null, returning null instead of throwing.
		#endregion

		#region Part01_Problem12
		/*
         Problem: Switch expression for days of week.
        */
		static void SwitchExpressionDemo()
		{
			Console.Write("Enter day: ");
			string day = Console.ReadLine();
			int dayNumber = day switch
			{
				"Monday" => 1,
				"Tuesday" => 2,
				"Wednesday" => 3,
				"Thursday" => 4,
				"Friday" => 5,
				"Saturday" => 6,
				"Sunday" => 7,
				_ => 0
			};
			Console.WriteLine($"Day number: {dayNumber}");
		}

		// Question: When is a switch expression preferred over a traditional if statement?
		// Answer: When mapping a single value to another value in a concise, readable way.
		#endregion

		#region Part01_Problem13
		/*
         Problem: SumArray with params keyword.
        */
		static int SumArray(params int[] numbers)
		{
			int sum = 0;
			foreach (var n in numbers)
				sum += n;
			return sum;
		}

		// Question: What are the limitations of the params keyword in method definitions?
		// Answer: Only one params parameter is allowed and it must be the last parameter.
		#endregion

		// ------------------ Part 02 ------------------

		#region Part02_Program1
		static void PrintNumbersInRange()
		{
			Console.Write("Enter a positive integer: ");
			int n = int.Parse(Console.ReadLine());
			for (int i = 1; i <= n; i++)
				Console.Write(i + (i < n ? ", " : "\n"));
		}
		#endregion

		#region Part02_Program2
		static void MultiplicationTable()
		{
			Console.Write("Enter an integer: ");
			int n = int.Parse(Console.ReadLine());
			for (int i = 1; i <= 12; i++)
				Console.WriteLine($"{n} x {i} = {n * i}");
		}
		#endregion

		#region Part02_Program3
		static void ListEvenNumbers()
		{
			Console.Write("Enter a number: ");
			int n = int.Parse(Console.ReadLine());
			for (int i = 2; i <= n; i += 2)
				Console.Write(i + (i < n ? ", " : "\n"));
		}
		#endregion

		#region Part02_Program4
		static void Exponentiation()
		{
			Console.Write("Enter base: ");
			int a = int.Parse(Console.ReadLine());
			Console.Write("Enter exponent: ");
			int b = int.Parse(Console.ReadLine());
			int result = 1;
			for (int i = 0; i < b; i++)
				result *= a;
			Console.WriteLine($"Result: {result}");
		}
		#endregion

		#region Part02_Program5
		static void ReverseString()
		{
			Console.Write("Enter a string: ");
			string str = Console.ReadLine();
			char[] arr = str.ToCharArray();
			Array.Reverse(arr);
			Console.WriteLine(new string(arr));
		}
		#endregion

		#region Part02_Program6
		static void ReverseInteger()
		{
			Console.Write("Enter an integer: ");
			string num = Console.ReadLine();
			char[] arr = num.ToCharArray();
			Array.Reverse(arr);
			Console.WriteLine(new string(arr));
		}
		#endregion

		#region Part02_Program7
		static void LongestDistanceBetweenMatchingElements()
		{
			Console.Write("Enter array size: ");
			int n = int.Parse(Console.ReadLine());
			int[] arr = new int[n];
			for (int i = 0; i < n; i++)
			{
				Console.Write($"Enter element {i}: ");
				arr[i] = int.Parse(Console.ReadLine());
			}
			int maxDist = 0;
			for (int i = 0; i < n; i++)
				for (int j = i + 1; j < n; j++)
					if (arr[i] == arr[j] && (j - i - 1) > maxDist)
						maxDist = j - i - 1;
			Console.WriteLine($"Longest distance: {maxDist}");
		}
		#endregion

		#region Part02_Program8
		static void ReverseWordsInSentence()
		{
			Console.Write("Enter a sentence: ");
			string sentence = Console.ReadLine();
			string[] words = sentence.Split(' ');
			Array.Reverse(words);
			Console.WriteLine(string.Join(" ", words));
		}
		#endregion
	}
}
