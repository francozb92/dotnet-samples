internal class UnsafeAccessorExample<T>
{
    public void AccessGenericType(Class<T> c)
    {
        ref T f = ref Accessors<T>.GetSetPrivateField(c);
        Accessors<T>.CallM<string>(c, f, string.Empty);
    }
}
