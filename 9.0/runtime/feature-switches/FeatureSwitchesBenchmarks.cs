using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class FeatureSwitchesBenchmarks
{
  [Benchmark]
  public void Feature_IsSupported_Disabled()
  {
    if (Feature.IsSupported)
    Feature.Implementation();
  }

}
