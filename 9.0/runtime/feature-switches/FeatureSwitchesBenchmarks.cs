using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class FeatureSwitchesBenchmarks
{
  [Params(true, false)]
  public bool IsSupported { get; set; }

  [Benchmark]
  public void FeatureSwitches_Benchmark()
  {
    if (IsSupported){
         Feature.Implementation();
    }  
  }
}
