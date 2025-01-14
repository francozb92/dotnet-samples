using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int[] array = new int[1000000]; // 1 million elements

        // Initialize the array with random values
        Random rand = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(0, 100); // random values between 0 and 99
        }

        // Measure the execution time of the incrementing loop
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int max = int.MinValue;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        stopwatch.Stop();
        Console.WriteLine("Incrementing loop: {0} ms", stopwatch.ElapsedMilliseconds);

        // Measure the execution time of the decrementing loop
        stopwatch.Reset();
        stopwatch.Start();
        max = int.MinValue;
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        stopwatch.Stop();
        Console.WriteLine("Decrementing loop: {0} ms", stopwatch.ElapsedMilliseconds);
    }
}