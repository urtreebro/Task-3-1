using System;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace classarrays
{
    partial class Program
    {
        public static void Main()
        {
            //one dimensional arrays
            Console.WriteLine("Create one dimensional array");
            Console.WriteLine("Input array length");
            Console.WriteLine("Then write 'true' if you want to input array by yourself");
            Console.WriteLine("Otherwise write 'false'");

            OneDimensionalArray onedimarray = new(int.Parse(Console.ReadLine()), bool.Parse(Console.ReadLine()));
            onedimarray.PrintArray();

            Console.WriteLine($"Average: {onedimarray.GetAverageNum()}");

            Console.WriteLine("Printed array with number abs 100");
            PrintArray(onedimarray.GetArrayAbs100());

            Console.WriteLine("Printed array without duplicates");
            PrintArray(onedimarray.GetArrayWithoutDuplicates());


            //two dimensional arrays
            Console.WriteLine("Create two dimensional array");
            Console.WriteLine("Input number of rows and columns");
            Console.WriteLine("Then write 'true' if you want to input array by yourself");
            Console.WriteLine("Otherwise write 'false'");

            TwoDimensionalArray twodimarray = new(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), bool.Parse(Console.ReadLine()));
            twodimarray.PrintArray();

            Console.WriteLine($"Average: {twodimarray.GetAverageNum()}");
           
            Console.WriteLine($"Determinant: {twodimarray.GetMatrixDeterminant()}");


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

        }
        public static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }
        public static void PrintArray(double[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }
        public static int[] InputOneDimensionalArray(int n)
        {
            int[] array = new int[n];

            Random rnd = new();

            for (int i = 0; i < array.Length; i++)
            {
                int value = rnd.Next(-1000, 1000);
                array[i] = value;
            }
            return array;
        }
        public static int[,] InputTwoDimensionalArray(int n, int m)
        {
            int[,] array = new int[n, m];

            Random rnd = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int value = rnd.Next(-1000, 1000);
                    array[i, j] = value;
                }
            }
            return array;
        }
        public static int[][] InputJaggedArray(int n)
        {
            int[][] array = new int[n][];

            Random rnd = new();

            for (int i = 0; i < n; i++)
            {
                int m = rnd.Next(1, 10);
                int[] row = new int[m];

                for (int j = 0; j < m; j++)
                {
                    int num = rnd.Next(-1000, 1000);
                    row[j] = num;
                }
                array[i] = row;
            }
            return array;
        }
     }
}