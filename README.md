## Purpose ##

This sample demonstrates the usage of [Configuration](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.2) provided by Microsoft.Extensions.* namespaces in a .NET Core console appllication.

To use the Configuration extensions, add related packages to the project as below to add configurations from environment variables and JSON file.

```
dotnet add package Microsoft.Extensions.Configuration.EnvironmentVariables
dotnet add package Microsoft.Extensions.Configuration.Json
```

To resemble behaviour of ASP.NET Core, in which a seperated configuration file for current environment is used, we read the environment variables with prefix "CONSOLEAPP_" into a `IConfigurationRoot` then read environment variable "CONSOLEAPP_ENVIRONMENT" in as current environment name.

```
var configEnv = configBuilder
    .AddEnvironmentVariables(prefix: "CONSOLEAPP_")
    .Build();
var env = configEnv["CONSOLEAPP_ENVIRONMENT"] ?? "Development";
```

The prefix is arbitrary to the project, for ASP.NET Core, it is "ASPNETCORE_".

