using System;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;

namespace TaskDay04Cs
{

    enum DayOfWeek
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Problem1
            // ---------------------- Problem ----------------------
            // Write a program that:
            // - Initializes a one-dimensional array in three different ways:
            //     1. Using new int[size]
            //     2. Using initializer list
            //     3. Using array syntax sugar
            //
            // - Assigns values to each element in the array and prints them.
            // - Demonstrates an IndexOutOfRangeException.

            // ---------------------- Solution ----------------------

            // 1. Using new int[size]
            int[] array1 = new int[3];
            array1[0] = 10;
            array1[1] = 20;
            array1[2] = 30;

            Console.WriteLine("Array 1 (using new int[size]):");
            foreach (int value in array1)
            {
                Console.WriteLine(value);
            }

            // 2. Using initializer list
            int[] array2 = new int[] { 100, 200, 300 };
            Console.WriteLine("\nArray 2 (using initializer list):");
            foreach (int value in array2)
            {
                Console.WriteLine(value);
            }

            // 3. Using array syntax sugar
            int[] array3 = { 1000, 2000, 3000 };
            Console.WriteLine("\nArray 3 (using syntax sugar):");
            foreach (int value in array3)
            {
                Console.WriteLine(value);
            }

            // Demonstrating IndexOutOfRangeException
            try
            {
                Console.WriteLine("\nTrying to access index 5 in array1:");
                Console.WriteLine(array1[5]); // This will throw an exception
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Caught an IndexOutOfRangeException: " + ex.Message);
            }

            // ---------------------- Question ----------------------
            // What is the default value assigned to array elements in C#?

            // ---------------------- Answer ------------------------
            // The default value assigned to array elements in C# depends on the type:
            // - For value types like int, the default is 0
            // - For value types like bool, the default is false
            // - For reference types like string or objects, the default is null

            #endregion

            #region Problem2
            // ---------------------- Problem ----------------------
            // Write a program to:
            // - Create two arrays (arr1 and arr2).
            // - Perform a shallow copy and demonstrate how modifying one affects the other.
            // - Perform a deep copy using the Clone method and show that modifications do not
            //   affect the copied array.

            // ---------------------- Solution ----------------------

            // Original array
            int[] arr1 = { 1, 2, 3, 4, 5 };

            // Shallow copy: both arr1 and arr2 point to the same array in memory
            int[] arr2 = arr1;
            arr2[0] = 99; // Change the first element in arr2

            Console.WriteLine("After shallow copy and modifying arr2:");
            Console.WriteLine("arr1: " + string.Join(", ", arr1)); // arr1 is affected
            Console.WriteLine("arr2: " + string.Join(", ", arr2)); // arr2 shows the change

            // Deep copy using Clone()
            int[] arr3 = (int[])arr1.Clone(); // Clone creates a new copy of the array
            arr3[1] = 100; // Change second element in arr3

            Console.WriteLine("\nAfter deep copy and modifying arr3:");
            Console.WriteLine("arr1: " + string.Join(", ", arr1)); // arr1 is NOT affected
            Console.WriteLine("arr3: " + string.Join(", ", arr3)); // arr3 shows the change

            // ---------------------- Question ----------------------
            // What is the difference between Array.Clone() and Array.Copy()?

            // ---------------------- Answer ------------------------
            // - Array.Clone():
            //   Returns a shallow copy of the array as an object. For one-dimensional arrays
            //   of value types (like int), it behaves like a deep copy.
            //
            // - Array.Copy():
            //   Copies elements from a source array to a destination array, allowing more
            //   control (such as specifying starting indexes). It is used for deep copying
            //   elements from one array to another.

            #endregion

            #region Problem 3
            //// ---------------------- Problem ----------------------
            //// Write a program to:
            //// - Create a 2D array with student grades (3 students, 3 subjects each).
            //// - Take input from the user to fill the array.
            //// - Print the grades for each student using nested loops.

            //// ---------------------- Solution ----------------------

            //int[,] grades = new int[3, 3]; // 3 students, 3 subjects

            //Console.WriteLine("Enter grades for 3 students (each has 3 subjects):");

            //// Input grades from user
            //for (int i = 0; i < grades.GetLength(0); i++) // rows (students)
            //{
            //    for (int j = 0; j < grades.GetLength(1); j++) // columns (subjects)
            //    {
            //        Console.Write($"Enter grade for Student {i + 1}, Subject {j + 1}: ");
            //        grades[i, j] = int.Parse(Console.ReadLine());
            //    }
            //}

            //Console.WriteLine("\nGrades of each student:");

            //// Print grades using nested loops
            //for (int i = 0; i < grades.GetLength(0); i++)
            //{
            //    Console.Write($"Student {i + 1}: ");
            //    for (int j = 0; j < grades.GetLength(1); j++)
            //    {
            //        Console.Write(grades[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            //// ---------------------- Question ----------------------
            //// What is the difference between GetLength() and Length for multi-dimensional arrays?

            //// ---------------------- Answer ------------------------
            //// - GetLength(dimension):
            ////   Returns the number of elements in the specified dimension.
            ////   For example, arr.GetLength(0) gives number of rows,
            ////   and arr.GetLength(1) gives number of columns.
            ////
            //// - Length:
            ////   Returns the total number of elements in the entire array.
            ////   For a 2D array of 3x3, arr.Length returns 9.

            #endregion

            #region Problem4
            // ---------------------- Problem ----------------------
            // Write a program that:
            // - Demonstrates at least 5 array methods:
            //   Sort, Reverse, IndexOf, Copy, Clear
            // - Explains the changes before and after applying each method.

            // ---------------------- Solution ----------------------

            int[] numbers = { 5, 2, 8, 1, 9 };

            Console.WriteLine("Original array:");
            Console.WriteLine(string.Join(", ", numbers));

            // 1. Sort
            Console.WriteLine("\nApplying Array.Sort():");
            Array.Sort(numbers);
            Console.WriteLine("Array after sorting (ascending):");
            Console.WriteLine(string.Join(", ", numbers));

            // 2. Reverse
            Console.WriteLine("\nApplying Array.Reverse():");
            Array.Reverse(numbers);
            Console.WriteLine("Array after reversing:");
            Console.WriteLine(string.Join(", ", numbers));

            // 3. IndexOf
            Console.WriteLine("\nApplying Array.IndexOf():");
            int index = Array.IndexOf(numbers, 8);
            Console.WriteLine("Index of value 8: " + index);

            // 4. Copy
            Console.WriteLine("\nApplying Array.Copy():");
            int[] copiedArray = new int[numbers.Length];
            Array.Copy(numbers, copiedArray, numbers.Length);
            Console.WriteLine("Copied array:");
            Console.WriteLine(string.Join(", ", numbers));

            // 5. Clear
            Console.WriteLine("\nApplying Array.Clear():");
            Array.Clear(numbers, 1, 2); // Clear 2 elements starting from index 1
            Console.WriteLine("Array after clearing 2 elements starting at index 1:");
            Console.WriteLine(string.Join(", ", numbers));

            // ---------------------- Question ----------------------
            // What is the difference between Array.Copy() and Array.ConstrainedCopy()?

            // ---------------------- Answer ------------------------
            // - Array.Copy():
            //   - Copies elements from one array to another.
            //   - May fail partway through and leave the destination array partially modified.
            //
            // - Array.ConstrainedCopy():
            //   - Guarantees atomic (all-or-nothing) copy.
            //   - If the copy fails, the destination array remains unchanged.
            //   - Commonly used in security-sensitive or critical environments.

            #endregion

            #region Problem5
            // ---------------------- Problem ----------------------
            // Create a program that:
            // - Uses a for loop to print all elements of a 1D array.
            // - Uses a foreach loop to print all elements of the same array.
            // - Uses a while loop to print all elements in reverse order.

            // ---------------------- Solution ----------------------

            int[] numbers1 = { 10, 20, 30, 40, 50 };

            // Using for loop
            Console.WriteLine("Using for loop:");
            for (int i = 0; i < numbers1.Length; i++)
            {
                Console.WriteLine(numbers1[i]);
            }

            // Using foreach loop
            Console.WriteLine("\nUsing foreach loop:");
            foreach (int num in numbers1)
            {
                Console.WriteLine(num);
            }

            // Using while loop (in reverse order)
            Console.WriteLine("\nUsing while loop (reverse order):");
            int index1 = numbers1.Length - 1;
            while (index1 >= 0)
            {
                Console.WriteLine(numbers1[index1]);
                index1--;
            }

            // ---------------------- Question ----------------------
            // Why is foreach preferred for read-only operations on arrays?

            // ---------------------- Answer ------------------------
            // - foreach is preferred for read-only operations because:
            //   - It is more concise and readable.
            //   - It prevents accidental modification of array elements.
            //   - It hides index logic, reducing chances of errors like IndexOutOfRangeException.
            // - However, foreach cannot be used to modify elements directly.

            #endregion


            #region Problem6
            // ---------------------- Problem ----------------------
            // Write a program that:
            // - Repeatedly asks the user for a positive odd number.
            // - Uses defensive coding to validate input using int.TryParse and a do-while loop.

            // ---------------------- Solution ----------------------

            int number;
            do
            {
                Console.Write("Enter a positive odd number: ");
                string input1 = Console.ReadLine();

                if (!int.TryParse(input1, out number) || number <= 0 || number % 2 == 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive odd number.");
                }

            } while (number <= 0 || number % 2 == 0);

            Console.WriteLine($"You entered: {number}");

            // ---------------------- Question ----------------------
            // Why is input validation important when working with user inputs?

            // ---------------------- Answer ------------------------
            // - Input validation prevents unexpected crashes and errors.
            // - It protects against invalid or malicious input.
            // - Ensures the program logic works on valid and expected data only.

            #endregion



            #region Problem7
            // ---------------------- Problem ----------------------
            // Write a program to:
            // - Create a 2D array with fixed values.
            // - Print the array elements in a matrix format (rows and columns).

            // ---------------------- Solution ----------------------

            int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

            Console.WriteLine("\n2D Array in matrix format:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // ---------------------- Question ----------------------
            // How can you format the output of a 2D array for better readability?

            // ---------------------- Answer ------------------------
            // - Use tab spaces (\t) or fixed-width formatting for consistent alignment.
            // - Print each row on a new line.
            // - You can also use String.Format or interpolation for padding numbers.

            #endregion

            #region Problem8
            // ---------------------- Problem ----------------------
            // Write a program that:
            // - Asks the user to enter a month number.
            // - Uses an if-else statement to determine the month name.
            // - Uses a switch statement to perform the same task.
            //في طرق اسهل  من كده بكتير 

            // ---------------------- Solution ----------------------

            Console.Write("\nEnter a month number (1-12): ");
            int month = int.Parse(Console.ReadLine());

            // Using if-else
            Console.Write("Using if-else: ");
            if (month == 1) Console.WriteLine("January");
            else if (month == 2) Console.WriteLine("February");
            else if (month == 3) Console.WriteLine("March");
            else if (month == 4) Console.WriteLine("April");
            else if (month == 5) Console.WriteLine("May");
            else if (month == 6) Console.WriteLine("June");
            else if (month == 7) Console.WriteLine("July");
            else if (month == 8) Console.WriteLine("August");
            else if (month == 9) Console.WriteLine("September");
            else if (month == 10) Console.WriteLine("October");
            else if (month == 11) Console.WriteLine("November");
            else if (month == 12) Console.WriteLine("December");
            else Console.WriteLine("Invalid month");

            // Using switch
            Console.Write("Using switch: ");
            switch (month)
            {
                case 1: Console.WriteLine("January"); break;
                case 2: Console.WriteLine("February"); break;
                case 3: Console.WriteLine("March"); break;
                case 4: Console.WriteLine("April"); break;
                case 5: Console.WriteLine("May"); break;
                case 6: Console.WriteLine("June"); break;
                case 7: Console.WriteLine("July"); break;
                case 8: Console.WriteLine("August"); break;
                case 9: Console.WriteLine("September"); break;
                case 10: Console.WriteLine("October"); break;
                case 11: Console.WriteLine("November"); break;
                case 12: Console.WriteLine("December"); break;
                default: Console.WriteLine("Invalid month"); break;
            }

            // ---------------------- Question ----------------------
            // When should you prefer a switch statement over if-else?

            // ---------------------- Answer ------------------------
            // - Use switch when checking a single variable against multiple constant values.
            // - It improves readability and performance for many conditions.
            // - Prefer if-else when using complex conditions or ranges.

            #endregion

            #region Problem9
            // ---------------------- Problem ----------------------
            // Write a program to:
            // - Sort an array of integers using Array.Sort().
            // - Search for a specific value using Array.IndexOf() and Array.LastIndexOf().

            // ---------------------- Solution ----------------------

            int[] nums = { 4, 2, 7, 2, 9, 2 };
            Console.WriteLine("\nOriginal array: " + string.Join(", ", nums));

            Array.Sort(nums);
            Console.WriteLine("Sorted array: " + string.Join(", ", nums));

            int indexx1 = Array.IndexOf(nums, 2);
            int index2 = Array.LastIndexOf(nums, 2);
            Console.WriteLine($"First index of 2: {indexx1}");
            Console.WriteLine($"Last index of 2: {index2}");

            // ---------------------- Question ----------------------
            // What is the time complexity of Array.Sort()?

            // ---------------------- Answer ------------------------
            // - Array.Sort() uses an O(n log n) time complexity algorithm (QuickSort or IntroSort).
            // - It's efficient for most general-purpose sorting tasks.

            #endregion

            #region Problem10
            // ---------------------- Problem ----------------------
            // Write a program that:
            // - Creates an array of integers.
            // - Uses a for loop to calculate and print the sum of all elements.
            // - Uses a foreach loop to calculate the same sum.

            // ---------------------- Solution ----------------------

            int[] values = { 3, 6, 9, 12 };

            int sumFor = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sumFor += values[i];
            }
            Console.WriteLine($"\nSum using for loop: {sumFor}");

            int sumForeach = 0;
            foreach (int val in values)
            {
                sumForeach += val;
            }
            Console.WriteLine($"Sum using foreach loop: {sumForeach}");

            // ---------------------- Question ----------------------
            // Which loop (for or foreach) is more efficient for calculating the sum of an array, and why?

            // ---------------------- Answer ------------------------
            // - Both for and foreach have similar performance for simple operations.
            // - foreach is more readable and safer (no index errors).
            // - for may be slightly faster in performance-critical scenarios due to less overhead.

            #endregion

            #region part2 
            Console.Write("Enter a number (1 to 7): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int dayNumber))
            {
                if (Enum.IsDefined(typeof(DayOfWeek), dayNumber))
                {
                    // Convert number to enum value using Enum.Parse
                    DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayNumber.ToString());
                    Console.WriteLine("Day: " + day);
                }
                else
                {
                    Console.WriteLine("Error: Number must be between 1 and 7.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            // ---------------------- Question ------------------------
            // What happens if the user enters a value outside the range of 1 to 7?
            //
            // Answer:
            // - If the number is outside 1 to 7 and you use Enum.Parse without validation,
            //   it will still convert it to an invalid enum value, which can cause logic errors.
            // - Using Enum.IsDefined prevents this by checking if the value exists in the enum.

            #endregion

            #region self Study


            //            What is a Jagged Array?
            //A jagged array is an array of arrays where each inner array can have a different length.
            //It’s like a 2D array, but the rows don’t have to be the same size.


            //                What is an Array of Objects?
            //An array of objects is an array that stores multiple instances of a class.
            //Each element in the array is a reference to an object.

//            1.What’s the default size of stack and heap, and what are the considerations?

//The default stack size in most systems is around 1MB, while the heap can grow much larger depending on system memory.

//Stack size is limited because it’s fast and used for function calls and local variables, while the heap is larger but slower and used for dynamic memory allocation.

//2.What is time complexity ?

//Time complexity describes how the runtime of an algorithm grows relative to the input size(n).

//It helps in analyzing performance and efficiency, typically expressed using Big O notation like O(n), O(log n), or O(n²).
            #endregion
           Console.ReadKey();
        }
    }
}
