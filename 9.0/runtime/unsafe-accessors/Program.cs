var exampleInt = new UnsafeAccessorExample<int>();
var exampleString = new UnsafeAccessorExample<string>();
var fieldIntValue = 5;
var fieldStringValue = "TEST";
var testClassInt = new GenericImplementationClass<int>(fieldIntValue);
exampleInt.AccessGenericType(testClassInt);
var testClassString = new GenericImplementationClass<string>(fieldStringValue);
exampleString.AccessGenericType(testClassString);




