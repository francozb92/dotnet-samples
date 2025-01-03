// See https://aka.ms/new-console-template for more information
using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Running;

Console.WriteLine("This is a sample project about feature switches in dotnet 9.0 runtime");
var summary = BenchmarkRunner.Run<FeatureSwitchesBenchmarks>();


//Base example

public class Feature
{
    [FeatureSwitchDefinition("Feature.IsSupported")]
    internal static bool IsSupported => AppContext.TryGetSwitch("Feature.IsSupported", out bool isEnabled) ? isEnabled : true;

    internal static void Implementation() => Console.WriteLine("Hello from feature enabled!");
}

