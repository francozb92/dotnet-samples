### dotnet-samples

## dotnet runtime

# garbage collection

For the purpose of showing this new feature we will setup an example API project which will be subject to load testing using K6 which is a testing framework for systems under stress and navigate through the diagnostics tool and see the performance improvements that garbage collection brings in this version of the framework. The project we will be using is based on https://code-maze.com/aspnetcore-performance-testing-with-k6/.

The new improvement is called Dynamic Adaptation To Application Sizes (DATAS) which aims to establish a maximum number of memory allocations based on long-lived data size. It would be interesting to consider how it allocates/frees memory dynamically. Does it keep track of the location in memory of certain allocations that lie outside the maximum heap size threshold or is it arbitrarily picked in the sense that what if 1 allocation is 1MB and another 10MB. Are they stored sequentally in memory or in different memory addresses far apart? How does the garbage collector dynamically deals with the heap size which is the amount of memory available in the computer and reclaims back the heap space previously allocated to objects not longer needed. The answers to these questions are a different topic of discussion outside the scope of this example. 

If you would like to know more information about this new feature follow along below[^1].

The garbage collector can be configured to use DATAS. DATAS adapts to application memory requirements, meaning the app heap size should be roughly proportional to the long-lived data size.
Starting in this new version of the framework it comes enabled by default.

| Setting name | Value | Display Value |
| --- | --- | --- |
| Environment variable | DOTNET_GCDynamicAdaptationMode | 1 - enabled, 0 - disabled |
| MSBuild property | GarbageCollectionAdaptationMode | 1 - enabled, 0 - disabled |
| runtimeconfig.json | System.GC.DynamicAdaptationMode | 1 - enabled, 0 - disabled |


- It sets the maximum amount of allocations allowed before the next GC is triggered based on the long-lived data size. This helps with constraining the heap size.
- It sets the actual amount of allocations allowed based on throughput.
- It adjusts the number of heaps when needed. It starts with one heap, which means if there are many threads allocating, some will need to wait. That negatively affects throughput. DATAS grows and reduces the number of heaps as needed. In this way, it's a hybrid between the existing GC modes, capable of using as few as one heap (like workstation GC) and as many as matches the machine core count (like server GC).
- When needed, it does full-compacting GCs to prevent fragmentation from getting too high, which also helps with constraining the heap size

[^1]: Dynamic adaptation to application sizes (DATAS) [supporting link](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/datas).
