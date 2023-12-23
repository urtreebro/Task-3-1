using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftWindowsWPF;


namespace benchmarks
{
    class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run<Benchmark>();
        }
        
    }
    [MemoryDiagnoser]
    public class Benchmark
    {
        private int[] array;

        [Params(8, 16, 32, 128, 1024, 10000, 100000)]
        public int N;

        [IterationSetup]
        public void Setup()
        {
            array = Sort.CreateArray(N);
        }
        [Benchmark]
        public void TestQSort()
        {  
            Sort.QSort(array);
        }
        [Benchmark]
        public void TestInsertSort()
        {
            Sort.InsertSort(array);
        }
        [Benchmark]
        public void TestShellSort()
        {
            Sort.ShellSort(array);
        }
        [Benchmark]
        public void TestBubbleSort()
        {
            Sort.BubbleSort(array);
        }
        [Benchmark]
        public void TestHeapSort()
        {
            Sort.HeapSort(array);
        }
    }
    public class Sort
    {
        static public int[] CreateArray(int n)
        {
            int[] array = new int[n];
            Random rnd = new();
            for (int i = 0; i < array.Length; i++)
            {
                int value = rnd.Next(0, 100);
                array[i] = value;
            }
            return array;
        }
        public static int[] InsertSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                int k = array[i];
                while (j > 0 && array[j - 1] > k)
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = k;
            }
            return array;
        }
        public static int[] QSort(int[] array)
        {
            return QSort(array, 0, array.Length - 1);
        }
        private static void Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }
        static int[] QSort(int[] array, int minindex, int maxindex)
        {
            if (minindex >= maxindex)
            {
                return array;
            }
            int pivotindex = Partition(array, minindex, maxindex);
            QSort(array, minindex, pivotindex - 1);
            QSort(array, pivotindex + 1, maxindex);
            return array;
        }
        private static int Partition(int[] array, int minindex, int maxindex)
        {
            int pivot = minindex - 1;
            for (int i = minindex; i < maxindex; i++)
            {
                if (array[i] < array[maxindex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }
            pivot++;
            Swap(ref array[pivot], ref array[maxindex]);
            return pivot;
        }
        public static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
            return array;
        }
        public static int[] HeapSort(int[] array)
        {
            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(array, array.Length, i);
            }
            for (int i = array.Length - 1; i >= 0; i--)
            {
                Swap(ref array[0], ref array[i]);
                Heapify(array, i, 0);
            }
            return array;
        }
        private static void Heapify(int[] array, int n, int i)
        {
            int max = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            if (l < n && array[l] > array[max])
            {
                max = l;
            }
            if (r < n && array[r] > array[max])
            {
                max = r;
            }
            if (max != i)
            {
                Swap(ref array[i], ref array[max]);
                Heapify(array, n, max);
            }
        }
        public static int[] ShellSort(int[] array)
        {
            int step = array.Length / 2;
            while (step >= 1)
            {
                for (int i = step; i < array.Length; i++)
                {
                    int j = i;
                    int k = array[i];
                    while (j >= step && array[j - step] > array[j])
                    {
                        Swap(ref array[j], ref array[j - step]);
                        j -= step;
                    }
                    array[j] = k;
                }
                step /= 2;
            }
            return array;
        }
    }
}