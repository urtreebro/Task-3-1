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

        private bool userInput;

        private OneDimensionalArray[] array;

        private static Random rnd = new();

        public JaggedArray(int n, bool userInput = false)
        {
            this.n = n;

            this.userInput = userInput;

            array = new OneDimensionalArray[n];

            if (userInput)
            {
                UserInput();
            }
            else
            {
                RandomInput();
            }
        }
        public int this[int index1, int index2]
        {
            get { return array[index1][index2]; }
        }
        public void Fill(int n, bool userInput = false)
        {
            this.n = n;

            array = new OneDimensionalArray[n];

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
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Input length of nested array");

                int m = int.Parse(Console.ReadLine());

                OneDimensionalArray nestedArray = new(m, true);

                array[i] = nestedArray;
            }
        }

        public void RandomInput()
        {
            for (int i = 0; i < n; i++)
            {
                OneDimensionalArray nestedArray = new(rnd.Next(1, 10));

                array[i] = nestedArray;
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
            double average = sum;
            return average;
        }

        public double[] GetAverageNumInNestedArrays()
        {
            double[] averageArray = new double[n];

            for (int i = 0; i < n; i++)
            {
                double average = array[i].GetAverageNum();

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
