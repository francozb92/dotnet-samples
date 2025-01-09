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

## Environment Variables

The `EnvironmentVariables` install search behavior is used to specify a .NET installation location based on environment variables.

When you set `AppHostDotNetSearch` to `EnvironmentVariables`, the .NET runtime will search for a .NET installation location based on the following environment variables:

* `DOTNET_ROOT`: This environment variable specifies the root directory of the .NET installation.
* `DOTNET_ROOT_<arch>`: This environment variable specifies the root directory of the .NET installation for a specific architecture (e.g. `x86`, `x64`, etc.).

The .NET runtime will search for a .NET installation location in the following order:

1. `DOTNET_ROOT_<arch>`: If the `DOTNET_ROOT_<arch>` environment variable is set, the .NET runtime will search for a .NET installation location in that directory.
2. `DOTNET_ROOT`: If the `DOTNET_ROOT` environment variable is set, the .NET runtime will search for a .NET installation location in that directory.
3. Default installation location: If neither of the above environment variables is set, the .NET runtime will search for a .NET installation location in the default installation location (e.g. `C:\Program Files\dotnet` on Windows).

- DOTNET_ROOT is an environment variable that specifies the root directory of the .NET runtime for all architectures (x86, x64, and arm64). This variable is used to specify the location of the .NET runtime for all applications, regardless of the architecture they are running on.

- DOTNET_ROOT(x86) is an environment variable that specifies the root directory of the .NET runtime for the x86 architecture. This variable is used to specify the location of the .NET runtime for 32-bit applications.

- DOTNET_ROOT_X86, on the other hand, is an environment variable that specifies the root directory of the .NET runtime for the x86 architecture, but it is specifically used for 64-bit applications that run on a 32-bit operating system.

- DOTNET_ROOT_X64, on the other hand, is an environment variable that specifies the root directory of the .NET runtime for x64 architecture only. This variable is used to specify the location of the .NET runtime for 64-bit applications that run on a 64-bit operating system.

**.NET Runtime Default Locations**

| Platform | Default Location |
| --- | --- |
| Windows | C:\Program Files\dotnet |
| macOS | /usr/local/share/dotnet |
| arm64 OS | C:\Program Files\dotnet\x64 (x64 runtimes) |
| Linux | varies depending on distro and installation method |

```

<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <RootNamespace>sample_app</RootNamespace>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <AppHostDotNetSearch>EnvironmentVariables</AppHostDotNetSearch>
    <EnvironmentVariable>DOTNET_ROOT=./path/to/runtime</EnvironmentVariable>
    <EnvironmentVariable>DOTNET_ROOT(x86)=./path/to/runtime/x86-apps/x86</EnvironmentVariable>
    <EnvironmentVariable>DOTNET_ROOT_X86=./path/to/runtime/x64-apps/x86</EnvironmentVariable>
    <EnvironmentVariable>DOTNET_ROOT_X64=./path/to/runtime/x64-apps/x64</EnvironmentVariable>
  </PropertyGroup>
</Project>

```

## Global

When you set `AppHostDotNetSearch` to `Global`, the .NET runtime will search for a .NET installation location that refers to the system-wide installation of the .NET runtime.

In other words, when you deploy a .NET application as a Global deployment, the .NET runtime is installed on the target machine as part of the .NET installation. This means that the .NET runtime is available to all applications on the machine, and it is not isolated to a specific application.

Global deployments are typically used when you want to deploy a .NET application to a machine that does not have the .NET runtime installed, or when you want to ensure that the .NET runtime is available to all applications on the machine.

Here are some benefits of deploying a .NET application as a Global deployment:

1. **System-wide availability**: The .NET runtime is installed on the target machine, making it available to all applications.
2. **No isolation**: The .NET runtime is not isolated to a specific application, which means that it can be shared by multiple applications.
3. **Easier deployment**: Global deployments are typically easier to deploy, as you only need to install the .NET runtime once on the target machine.
4. **Better performance**: Global deployments can improve performance, as the .NET runtime is cached on the machine and does not need to be downloaded and installed for each application.

However, Global deployments also have some drawbacks:

1. **Security risks**: Global deployments can increase the risk of security threats, as the .NET runtime is installed on the machine and can be accessed by multiple applications.
2. **Version conflicts**: Global deployments can lead to version conflicts, as multiple applications may require different versions of the .NET runtime.
3. **Maintenance challenges**: Global deployments can make maintenance more challenging, as updates to the .NET runtime may affect multiple applications.

```

<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <RootNamespace>sample_app</RootNamespace>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <AppHostDotNetSearch>Global</AppHostDotNetSearch>
  </PropertyGroup>
</Project>

```
