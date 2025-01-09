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

## AppRelative

AppRelative is a search location for the AppHostDotNetSearch property, which allows you to specify a relative path to a .NET installation. When you set AppHostDotNetSearch to AppRelative, the .NET runtime will search for a .NET installation in the specified relative path.

There are several reasons why you might want to search for a .NET installation in a path relative to the executable's location:

1. **Portability**: By specifying a relative path, you can make your application more portable across different environments. For example, if your application is deployed to a network share, you can specify a relative path that is relative to the share, rather than a fixed absolute path.
2. **Flexibility**: Relative paths allow you to change the location of the .NET installation without having to modify the application's configuration. For example, if you need to move the .NET installation to a different location, you can simply update the `AppHostRelativeDotNet` property to point to the new location.
3. **Security**: By specifying a relative path, you can reduce the risk of exposing sensitive information, such as the location of the .NET installation, in your application's configuration file.
4. **Multi-environment support**: Relative paths can be used to support multiple environments, such as development, testing, and production. For example, you can specify a relative path that is relative to the executable's location in the development environment, and a different relative path in the production environment.
5. **Dynamic configuration**: Relative paths can be used to create dynamic configurations that are based on the location of the executable. For example, you can use a relative path to specify a .NET installation that is located in the same directory as the executable, but with a different name.

```
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <RootNamespace>sample_app</RootNamespace>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <AppHostDotNetSearch>AppRelative</AppHostDotNetSearch>
    <AppHostRelativeDotNet>./relative/path/to/runtime</AppHostRelativeDotNet>
  </PropertyGroup>
</Project>

```
