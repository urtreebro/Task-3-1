using System;
class HelloWorld
{
    static void Main()
    {
        int[] array = CreateArray(int.Parse(Console.ReadLine()));
        //Task 1.1      
        Console.WriteLine(AverageNum(array));
        //Task 1.2
        PrintArray(NoLessThan100(array));
        //Task 1.3
        PrintArray(NoDuplicates(array));
        //Task 2
        PrintArray(InputArray(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
        PrintArray(InputArray2(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
        PrintArray(InputSnake(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
        //Task 3
        int[][] stepArray = InputArray(int.Parse(Console.ReadLine()));
        PrintArray(stepArray);
        ChangeArray(ref stepArray);
        PrintArray(stepArray);

    }
    static double AverageNum(int[] array)
    {
        double sum = 0;
        foreach (int num in array)
        {
            sum += num;
        }
        double average = sum / array.Length;
        return average;
    }
    static int[] NoLessThan100(int[] array)
    {
        int newLength = array.Length;
        foreach (int num in array)
        {
            if (Math.Abs(num) > 100)
            {
                newLength--;
            }
        }
        int[] newArray = new int[newLength];
        int newIndex = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (Math.Abs(array[i]) <= 100)
            {
                newArray[newIndex] = array[i];
                newIndex++;
            }

        }
        return newArray;
    }
    static int[] NoDuplicates(int[] array)
    {
        int newLength = array.Length;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i; j < array.Length; j++)
            {
                if (i != j && array[i] == array[j])
                {
                    newLength--;
                    break;
                }
            }
        }
        int[] newArray = new int[newLength];
        int newIndex = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (!newArray.Contains(array[i]))
            {
                newArray[newIndex] = array[i];
                newIndex++;
            }
        }
        return newArray;

    }
    static int[] CreateArray(int n)
    {
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                array[i] = num;
            }
        }
        return array;
    }
    static void PrintArray(int[] array)
    {
        Console.WriteLine(string.Join(" ", array));
    }
    static void PrintArray(int[,] a)
    {
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.Write(a[i, j]);
                Console.Write("\t");
            }
            Console.WriteLine();
        }
    }
    static int[,] InputArray(int n, int m)
    {
        int[,] array = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    array[i, j] = num;
                }
            }
        }
        return array;
    }
    static int[,] InputArray2(int n, int m)
    {
        int[,] array = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            string row = Console.ReadLine();
            string[] _row = row.Split(' ');
            for (int j = 0; j < _row.Length; j++)
            {
                array[i, j] = int.Parse(_row[j]);
            }
        }
        return array;
    }
    static int[,] InputSnake(int n, int m)
    {
        int[,] array = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < m; j++)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        array[i, j] = num;
                    }
                }
            }
            else
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    if (int.TryParse(Console.ReadLine(), out int num))
                    {
                        array[i, j] = num;
                    }
                }
            }
        }
        return array;
    }
    static void PrintArray(int[][] array)
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
    static int[][] InputArray(int n)
    {
        int[][] array = new int[n][];
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
        return array;
    }
    static void ChangeArray(ref int[][] array)
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
