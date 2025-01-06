### dotnet-samples

## dotnet runtime

# unsafe accessors

Nice feature to have in your codebase if you work with legacy libraries that require interoperability and don't want to use hardcore reflection implementation for reusability although I believe it must use reflection down the hood. I think it has great potential for interop services in C#, F#, and VB.NET when you need to use old C and C++ libraries or other dlls. It is esentially a fancy and concrete generic implementation of reflection.

It also gives you the ability to distinguish and have a clear picture of what is available when unaccessible calling is present within libraries and how it provides the capability of extending your codebase using generics and clean code to achieve your goals.