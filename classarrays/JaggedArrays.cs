using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classarrays
{
    partial class Program
    {
        public class JaggedArray
        {
            private int n;

            private int[][] array;

            private bool userInput;

            public JaggedArray(int n, bool userInput)
            {
                this.n = n;

                this.userInput = userInput;

                if (userInput)
                {
                    Console.WriteLine($"Input a row of numbers divided by spaces");
                    UserInput();
                }
                else
                {
                    RandomInput();
                }
            }

            public void UserInput()
            {
                array = new int[n][];

                for (int i = 0; i < n; i++)
                {
                    string row = Console.ReadLine();
                    string[] strRow = row.Split(' ');
                    int[] _row = new int[strRow.Length];

                    for (int j = 0; j < strRow.Length; j++)
                    {
                        _row[j] = int.Parse(strRow[j]);
                    }
                    array[i] = _row;
                }
            }

            public void RandomInput()
            {
                array = new int[n][];

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
            }

            public void PrintArray()
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        Console.Write(array[i][j] + "\t");
                    }
                    Console.WriteLine();
                }
            }

            public double GetAverageNum()
            {
                double sum = 0;

                int count = 0;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        sum += array[i][j];
                        count++;
                    }
                }
                double average = sum / count;
                return average;
            }

            public double[] GetAverageNumInNestedArrays()
            {
                double[] averageArray = new double[n];

                for (int i = 0; i < n; i++)
                {
                    double sum = 0;
                    int count = 0;

                    for (int j = 0; j < array[i].Length; j++)
                    {
                        sum += array[i][j];
                        count++;
                    }
                    double average = sum / count;
                    averageArray[i] = average;
                }
                return averageArray;
            }

            public void ChangeArray()
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        if (array[i][j] % 2 == 0)
                        {
                            array[i][j] = i * j;
                        }
                    }
                }
            }
        } 
    }
}
