using System;
using System.ComponentModel;

namespace classarrays
{
    partial class Program
    {
        public static void Main()
        {
            Console.WriteLine("Which array do you want to test?");
            Console.WriteLine("Write 'o' for one-dimensional array, 't' for two-dimensional array, write 'j' for jagged array, 'e' for exit");

            string userAnswer = Console.ReadLine(); 

            while (userAnswer != "e")
            {
                if (userAnswer == "o")
                {
                    //one dimensional arrays
                    Console.WriteLine("Create one dimensional array");
                    Console.WriteLine("Input array length");
                    Console.WriteLine("Then write 'true' if you want to input array by yourself. Otherwise write 'false'");

                    OneDimensionalArray onedimarray = new(int.Parse(Console.ReadLine()), bool.Parse(Console.ReadLine()));
                    onedimarray.PrintArray();

                    Console.WriteLine($"Average: {onedimarray.GetAverageNum()}");

                    Console.WriteLine("Printed array with number abs 100");
                    PrintArray(onedimarray.GetArrayAbs100());

                    Console.WriteLine("Printed array without duplicates");
                    PrintArray(onedimarray.GetArrayWithoutDuplicates());

                    Console.WriteLine("Refill array");
                    Console.WriteLine("Input array length");
                    Console.WriteLine("Then write 'true' if you want to input array by yourself. Otherwise write 'false'");

                    onedimarray.Fill(int.Parse(Console.ReadLine()), bool.Parse(Console.ReadLine()));
                    onedimarray.PrintArray();
                }


                if (userAnswer == "t")
                {
                    //two dimensional arrays
                    Console.WriteLine("Create two dimensional array");
                    Console.WriteLine("Input number of rows and columns");
                    Console.WriteLine("Then write 'true' if you want to input array by yourself. Otherwise write 'false'");

                    TwoDimensionalArray twodimarray = new(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), bool.Parse(Console.ReadLine()));
                    twodimarray.PrintArray();

                    Console.WriteLine($"Average: {twodimarray.GetAverageNum()}");
                    
                    if (twodimarray.Rows == twodimarray.Columns)
                    {
                        Console.WriteLine($"Determinant: {twodimarray.GetMatrixDeterminant()}");
                    }

                    Console.WriteLine("Refill array");
                    Console.WriteLine("Input number of rows and columns");
                    Console.WriteLine("Then write 'true' if you want to input array by yourself. Otherwise write 'false'");

                    twodimarray.Fill(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), bool.Parse(Console.ReadLine()));
                    twodimarray.PrintArray();
                }

                if (userAnswer == "j")
                {
                    //jagged arrays
                    Console.WriteLine("Create jagged array");
                    Console.WriteLine("Input number of rows");
                    Console.WriteLine("Then write 'true' if you want to input array by yourself");
                    Console.WriteLine("Otherwise write 'false'");

                    JaggedArray jaggedarray = new(int.Parse(Console.ReadLine()), bool.Parse(Console.ReadLine()));
                    jaggedarray.PrintArray();

                    Console.WriteLine($"Average: {jaggedarray.GetAverageNum()}");

                    Console.WriteLine("Average in nested arrays: ");
                    PrintArray(jaggedarray.GetAverageNumInNestedArrays());

                    jaggedarray.ChangeArray();
                    Console.WriteLine("Array which even values have been changed");
                    jaggedarray.PrintArray();

                    Console.WriteLine("Refill array");
                    Console.WriteLine("Input number of rows");
                    Console.WriteLine("Then write 'true' if you want to input array by yourself. Otherwise write 'false'");

                    jaggedarray.Fill(int.Parse(Console.ReadLine()), bool.Parse(Console.ReadLine()));
                    jaggedarray.PrintArray();
                }
                Console.WriteLine("Which array do you want to test?");
                Console.WriteLine("Write 'o' for one-dimensional array, 't' for two-dimensional array, write 'j' for jagged array, 'e' for exit");

                userAnswer = Console.ReadLine(); 
            }
        }
        public static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }
        public static void PrintArray(double[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}