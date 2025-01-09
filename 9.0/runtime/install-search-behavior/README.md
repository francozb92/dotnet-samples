### dotnet-samples

## dotnet runtime

# install search behavior

.NET apps can now be configured for how they should search for the .NET runtime. This capability can be used with private runtime installations or to more strongly control the execution environment[].

# AppHostDotNetSearch

- **AppHostDotNetSearch** is a property that allows you to specify one or more locations where the .NET runtime will search for a .NET installation. This property is used to specify the search path for the .NET runtime when it is looking for a .NET installation.

| Location | Description |
|----------|-------------|
| AppLocal  | The executable's own folder |
| AppRelative | A path relative to the executable's location |
| EnvironmentVariables | The value of the DOTNET_ROOT[_<arch>] environment variables |
| Global    | Registered and default global install locations |

## AppLocal

AppLocal is a feature in .NET that allows you to deploy your application with its own copy of the .NET runtime, rather than relying on the system-wide installation of the .NET runtime.

When you deploy an AppLocal application, the .NET runtime is included in the deployment package, and the application runs with its own isolated copy of the runtime. This means that the application can run independently of the system-wide .NET runtime installation, and it can also be deployed to machines that do not have the .NET runtime installed.

AppLocal is useful in scenarios where you need to deploy an application to a machine that does not have the .NET runtime installed, or where you need to ensure that the application runs with a specific version of the .NET runtime.

Here are some benefits of using AppLocal:

1. **Isolation**: AppLocal applications run with their own isolated copy of the .NET runtime, which means that they do not interfere with other applications that are running on the same machine.
2. **Portability**: AppLocal applications can be deployed to machines that do not have the .NET runtime installed, and they can also be deployed to machines that have a different version of the .NET runtime installed.
3. **Security**: AppLocal applications are isolated from the system-wide .NET runtime installation, which means that they are less vulnerable to security threats.
4. **Flexibility**: AppLocal applications can be deployed with a specific version of the .NET runtime, which means that you can ensure that the application runs with the correct version of the runtime.

```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <RootNamespace>sample_app</RootNamespace>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <AppHostDotNetSearch>AppLocal</AppHostDotNetSearch>
  </PropertyGroup>
</Project>

```

