using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classarrays
{
    class JaggedArray
    {
        private int n;

        private int[][] array;

        private bool userInput;

        public JaggedArray(int n, bool userInput = false)
        {
            this.n = n;

            this.userInput = userInput;

            if (userInput)
            {
                UserInput();
            }
            else
            {
                RandomInput();
            }
        }

        public void Fill(int n, bool userInput = false)
        {
            this.n = n;

            if (userInput)
            {
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
                Console.WriteLine("Input length of nested array");

                int m = int.Parse(Console.ReadLine());

                OneDimensionalArray nestedArray = new(m, true);

                array[i] = nestedArray.Array;
            }
        }

        public void RandomInput()
        {
            array = new int[n][];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Input length of nested array");

                int m = int.Parse(Console.ReadLine());

                OneDimensionalArray nestedArray = new(m);

                array[i] = nestedArray.Array;
            }
        }

        public void PrintArray()
        {
            Console.WriteLine("Printed array:");
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
