public class Class<T>
{
    public Class(T fieldValue)
    {
        _field = fieldValue;
        M<string>(_field, "Call from unsafe accessor..");
    }
    private T? _field;
    private void M<U>(T t, U u) { 
        Console.WriteLine(t);
        Console.WriteLine(u);
    }
}