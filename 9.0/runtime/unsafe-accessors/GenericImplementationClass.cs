public class GenericImplementationClass<T> : Class<T>
{
    public GenericImplementationClass(T fieldValue) : base(fieldValue)
    {
        Console.WriteLine($"Hello from generic unsafe accessor implementation with value {fieldValue} and type {typeof(T)}");
    }
}
