// Create arrays with 10, 100, 1000, and 1000000 values for induction variable widening benchmarking
using System.Diagnostics;

int[] smallArray = new int[10];
    int[] mediumArray = new int[100];
    int[] largeArray = new int[1000];
    int[] hugeArray = new int[1000000];

    // Fill the arrays with values
    for (int i = 0; i < smallArray.Length; i++)
    {
        smallArray[i] = i;
    }
    for (int i = 0; i < mediumArray.Length; i++)
    {
        mediumArray[i] = i * 2;
    }
    for (int i = 0; i < largeArray.Length; i++)
    {
        largeArray[i] = i * 3;
    }
    for (int i = 0; i < hugeArray.Length; i++)
    {
        hugeArray[i] = i * 4;
    }

// -------------------------------------------------------------------------------------------------------

//  Benchmarking elapsed time performance for 4 different size arrays without induction variable widening 

    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    InductionVariableWidening.SumWithoutIVW(smallArray, smallArray.Length);
    stopwatch.Stop();
    Console.WriteLine("Elapsed time for small array without induction variable widening: {0} seconds", stopwatch.ElapsedMilliseconds/1000);
    stopwatch.Reset();

    stopwatch.Start();
    InductionVariableWidening.SumWithoutIVW(mediumArray, mediumArray.Length);
    stopwatch.Stop();
    Console.WriteLine("Elapsed time for medium array without induction variable widening: {0} seconds", stopwatch.ElapsedMilliseconds/1000);
    stopwatch.Reset();
        
    stopwatch.Start();
    InductionVariableWidening.SumWithoutIVW(largeArray, largeArray.Length);
    stopwatch.Stop();
    Console.WriteLine("Elapsed time for large array without induction variable widening: {0} seconds", stopwatch.ElapsedMilliseconds/1000);
    stopwatch.Reset();

    stopwatch.Start();
    InductionVariableWidening.SumWithoutIVW(hugeArray, hugeArray.Length);
    stopwatch.Stop();
    Console.WriteLine("Elapsed time for huge array without induction variable widening: {0} seconds", stopwatch.ElapsedMilliseconds/1000);
    stopwatch.Reset();

// ------------------------------------------------------------------------------------------------------

//  Benchmarking elapsed time performance for 4 different size arrays with induction variable widening

    stopwatch.Start();
    InductionVariableWidening.SumWithIVW(smallArray, smallArray.Length);
    stopwatch.Stop();
    Console.WriteLine("Elapsed time for small array with induction variable widening: {0} seconds", stopwatch.ElapsedMilliseconds/1000);
    stopwatch.Reset();

    stopwatch.Start();
    InductionVariableWidening.SumWithIVW(mediumArray, mediumArray.Length);
    stopwatch.Stop();
    Console.WriteLine("Elapsed time for medium array with induction variable widening: {0} seconds", stopwatch.ElapsedMilliseconds/1000);
    stopwatch.Reset();
    
    stopwatch.Start();
    InductionVariableWidening.SumWithIVW(largeArray, largeArray.Length);
    stopwatch.Stop();
    Console.WriteLine("Elapsed time for large array with induction variable widening: {0} seconds", stopwatch.ElapsedMilliseconds/1000);
    stopwatch.Reset();

    stopwatch.Start();
    InductionVariableWidening.SumWithIVW(hugeArray, hugeArray.Length);
    stopwatch.Stop();
    Console.WriteLine("Elapsed time for huge array with induction variable widening: {0} seconds", stopwatch.ElapsedMilliseconds/1000);
    stopwatch.Reset();

// ------------------------------------------------------------------------------------------------------