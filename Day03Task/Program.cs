using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.IO;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Xml.Linq;

namespace Day03Task
{
    internal class Program
    {
        class Person
        {
            public string Name { get; set; }
        } 

        static void Main(string[] args)
        {


            #region Problem01


            Console.Write("Enter a number as a string: ");
            string userInput = Console.ReadLine();

            try
            {
                int parsedValue = int.Parse(userInput);
                Console.WriteLine("Value using int.Parse: " + parsedValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine("int.Parse failed: " + ex.Message);
            }

            try
            {
                int convertedValue = Convert.ToInt32(userInput);
                Console.WriteLine("Value using Convert.ToInt32: " + convertedValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Convert.ToInt32 failed: " + ex.Message);
            }
            // Question: What is the difference between int.Parse and Convert.ToInt32 when handling null inputs?
            // Answer:
            // int.Parse(null) => throws ArgumentNullException
            // Convert.ToInt32(null) => returns 0
            #endregion



            #region Problem02

            Console.Write("Enter a number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                Console.WriteLine("You entered: " + result);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            // Question: Why is TryParse recommended over Parse in user-facing applications?
            // Answer:
            // TryParse is recommended because it doesn't throw exceptions if the input is invalid.
            // Instead, it returns false and sets the output to 0.
            // This makes the program more efficient and user-friendly since it avoids crashes
            // and allows graceful error handling without using try-catch.
            #endregion


            #region Problem03

            object obj;

            obj = 42;
            Console.WriteLine("HashCode of int: " + obj.GetHashCode());

            obj = "Hello";
            Console.WriteLine("HashCode of string: " + obj.GetHashCode());

            obj = 3.14;
            Console.WriteLine("HashCode of double: " + obj.GetHashCode());

            // Question: Explain the real purpose of the GetHashCode() method.
            // Answer:
            // GetHashCode() returns an integer that represents the current object for use in hashing algorithms and data structures like hash tables.
            // It's mainly used to quickly locate objects in collections like Dictionary, HashSet, etc.
            // It is not guaranteed to be unique, but should be consistent during the lifetime of the object.

            #endregion


            #region Problem04

           
            var person1 = new Person { Name = "Ahmed" };

            var person2 = person1;

           
            person1.Name = "Hany";

            Console.WriteLine("Name from person2: " + person2.Name);

            // Question: What is the significance of reference equality in .NET?
            // Answer:
            // Reference equality means that two variables refer to the same object in memory.
            // In .NET, this is important because modifying the object through one reference
            // will affect all other references pointing to the same object.
            // This behavior is crucial to understand when working with classes (reference types).

            #endregion

            #region Problem05

            string message = "Hello";
            Console.WriteLine("HashCode before modification: " + message.GetHashCode());

            message += " Hi Willy";
            Console.WriteLine("HashCode after modification: " + message.GetHashCode());

            // Question: Why string is immutable in C#?
            // Answer:
            // In C#, strings are immutable, meaning their value cannot be changed after creation.
            // When you modify a string, a new string object is created in memory,
            // and the old one remains unchanged.
            // This improves safety, avoids unexpected side effects, and allows strings
            // to be safely shared across code without risk of modification.

            #endregion

            #region Problem06

           
            StringBuilder sb = new StringBuilder("Hi");
            Console.WriteLine("HashCode before modification: " + sb.GetHashCode());

            sb.Append(" Willy");
            Console.WriteLine("HashCode after modification: " + sb.GetHashCode());

            // Question: How does StringBuilder address the inefficiencies of string concatenation?
            // Answer:
            // StringBuilder is mutable, meaning it can change its content without creating a new object.
            // Unlike string concatenation, which creates a new string every time,
            // StringBuilder modifies the same object in memory.
            // This makes it more efficient when performing many modifications, especially inside loops.

            #endregion

            #region Problem07

            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int sum = num1 + num2;

            // 1. Using concatenation (+ operator)
            Console.WriteLine("Sum is " + num1 + " + " + num2 + " = " + sum);

            // 2. Using composite formatting (string.Format)
            Console.WriteLine(string.Format("Sum is {0} + {1} = {2}", num1, num2, sum));

            // 3. Using string interpolation ($)
            Console.WriteLine($"Sum is {num1} + {num2} = {sum}");

            // Question: Which string formatting method is most used and why?
            // Answer:
            // String interpolation ($) is the most commonly used method in modern C#.
            // It is more readable and cleaner than concatenation or string.Format.
            // It also reduces the chance of errors and makes the code easier to maintain.

            #endregion

            #region Problem08
            StringBuilder sb2 = new StringBuilder("Hello");

            // Append text
            sb.Append(" World");
            Console.WriteLine("After Append: " + sb2);

            // Replace a substring
            sb.Replace("World", "Willy");
            Console.WriteLine("After Replace: " + sb2);

            // Insert a string at specific position
            sb.Insert(0, "Hi, ");
            Console.WriteLine("After Insert: " + sb2);

            // Remove a portion of text
            sb.Remove(3, 4); // removes ", Hi"
            Console.WriteLine("After Remove: " + sb2);
            // Question: Explain how StringBuilder is designed to handle frequent modifications compared to strings.
            // Answer:
            // StringBuilder is designed to be mutable, meaning it does not create a new object with each modification.
            // Instead, it uses an internal buffer that can grow as needed.
            // This allows it to handle frequent changes like append, insert, replace, and remove more efficiently than the immutable string type.
            // In contrast, modifying a string multiple times results in creating many intermediate string objects, consuming more memory and CPU time.

            #endregion


            #region  Part 2

            //🔸 What is Enum in C#?

            //enum (short for enumeration) is a value type that lets you define a set of named constants.It makes your code more readable, maintainable, and less error-prone than using magic numbers.


            //enum WeekDays
            //    {
            //        Sunday,
            //        Monday,
            //        Tuesday,
            //        Wednesday,
            //        Thursday,
            //        Friday,
            //        Saturday
            //    }
            //🔸 When is Enum used?
            //You use enums when:

            //You have a group of related named values(like days, states, levels).

            //You want your code to be self-explanatory(e.g., Status.Approved instead of 3).

            //You want type safety with integer-like behavior.

            //🔸 Common built-in enums in C#:
            //Here are 3 commonly used built-in enums:

            //DayOfWeek → Represents days of the week

            //DayOfWeek today = DayOfWeek.Monday;
            //    ConsoleColor → Represents text and background colors in the console


            //Console.ForegroundColor = ConsoleColor.Red;
            //    FileAccess → Used in file handling to specify access mode(Read, Write, ReadWrite)


            //FileStream fs = new FileStream("file.txt", FileMode.Open, FileAccess.Read);

            #endregion





            #region StringVsStringBuilder

            /*
            Scenarios to use 'string':
            - When dealing with a small number of modifications.
            - When readability and simplicity matter more than performance.
            - When performing concatenation of a few values (e.g., building a single message).

            Scenarios to use 'StringBuilder':
            - When performing many modifications (append, insert, replace).
            - When working with large or dynamic text (e.g., building logs, reports).
            - When performance and memory efficiency are important.
            */

            #endregion


            #region UserDefinedConstructor

            // A user-defined constructor is a special method created by the programmer
            // It runs automatically when an object is created from a class
            // Its main role is to initialize the object's fields or properties with specific values
            // It replaces the default constructor if defined
            // Useful when you want to control how objects are initialized

            #endregion


            #region Compare between Array and LinkedList

            // Array:
            // - Fixed size after declaration (size must be known at creation).
            // - Stored in contiguous memory blocks.
            // - Fast access using index (O(1)).
            // - Inserting/removing elements is expensive (O(n)) because it requires shifting elements.
            // - Built-in type in C# (int[], string[], etc.).

            // LinkedList:
            // - Dynamic size (can grow/shrink at runtime).
            // - Elements (nodes) are stored in non-contiguous memory.
            // - Slower access (no indexing, must traverse node by node → O(n)).
            // - Easy insertion/deletion at any point (O(1) if you have reference to the node).
            // - Available as System.Collections.Generic.LinkedList<T> in C#.

            #endregion

        }




    }

}
