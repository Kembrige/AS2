using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int[] arraySizes = { 100, 500, 1000, 5000, 10000, 50000, 100000, 500000, 1000000 };

        foreach (int size in arraySizes)
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(-50, 51);
            }
            Stopwatch sw = new Stopwatch();
            long totalTime = 0;
            int numIterations = 10000;

            // Начало измерения времени выполнения алгоритма
            for (int j = 0; j < numIterations; j++)
            {
                int[] tempArr = new int[size];
                Array.Copy(arr, tempArr, size);

                sw.Start();
                QuickSort(tempArr, 0, size - 1);
                sw.Stop();

                totalTime += sw.ElapsedTicks;
                sw.Reset();
            }
            // Конец измерения времени выполнения алгоритма

            double averageTime = (double)totalTime / numIterations / Stopwatch.Frequency * 1000; // в миллисекундах
            Console.WriteLine("Размер: " + size + ", Время: " + averageTime + " ms");
        }
    }

    static void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);
            QuickSort(arr, left, pivot - 1);
            QuickSort(arr, pivot + 1, right);
        }
    }

    static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        int temp1 = arr[i + 1];
        arr[i + 1] = arr[right];
        arr[right] = temp1;
        return i + 1;
    }
}