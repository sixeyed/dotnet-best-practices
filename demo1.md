# .NET Best Practices

## Demo 1: WCF App

Run the app in VS and test with the WCF client.

### Bad example

This is a classic example where good practices are not being applied.

Service - [StateProvincesService.svc.cs](src/netfx/WideWorldImporters/WideWorldImporters.Services/StateProvincesService.svc.cs)

- Logging: custom log loader, everything is Info
- Configuration: static, parsed string values
- Dependencies: manually created, lifetime not managed - DbContext
- Functionality: custom caching, custom mapping

> This class is difficult to test, will have duplicated code and has functional issues

### Better example 

This example uses key best practices.

Service - [CitiesService.svc.cs](src/netfx/WideWorldImporters/WideWorldImporters.Services/CitiesService.svc.cs)

- Logging: logger from DI, different levels
- Configuration: not used directly
- Dependencies: injected, lifetime controlled by Autofac
- Functionality: separate classes for caching and mapping

> Dependency injection makes unit testing easier and the class only has code that it needs, other features are in other classes

Dependency - [MemoryCache.cs](src/netfx/WideWorldImporters/WideWorldImporters.Services/Caching/MemoryCache.cs)

- Logging: none (considered as framework code)
- Configuration: injected, strongly-typed
- Dependencies: injected, lifetime controlled by Autofac
- Functionality: clearly scoped, wrapper for Runtime cache

Dependency - [AppSettingsConfig.cs](src/netfx/WideWorldImporters/WideWorldImporters.Services/Config/AppSettingsConfig.cs)

- Functionality: clearly scoped, wrapper for string parsing

Dependency Injection - using Autofac in [Global.asax.cs](src/netfx/WideWorldImporters/WideWorldImporters.Services/Global.asax.cs)

- Functionality: manages lifetimes, configures implementations

> You can apply DI to older projects, but some of the details become brittle - instance context needs to be set in service (e.g. in [CitiesService.svc.cs](src/netfx/WideWorldImporters/WideWorldImporters.Services/CitiesService.svc.cs)) otherwise strange runtime behavior

### Other notes

References - [WideWorldImporters.Services.csproj](src/netfx/WideWorldImporters/WideWorldImporters.Services/WideWorldImporters.Services.csproj)

- Uses a mix of local binaries and NuGet packages

Runtime -

- .NET Framework is Windows only
- ASP.NET apps run in IIS 

Roadmap - [.NET Framework Support Policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-framework)

- .NET Framework 4.8 is the last version
- 4.8 support is tied to Windows version
- < 4.6.2 will be out of support in April 2022
