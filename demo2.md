# .NET Best Practices

## Demo 2: Web API app

Run the app in VS and test with Postman.

### Bad example

.NET Core makes it easy to apply best practices, but it's not mandatory and you can still write bad code :)

Controller - [StateProvincesController.cs](src/dotnet/WorldWideImporters/WorldWideImporters.Api/Controllers/StateProvincesController.cs)

- Logging: custom log loader, everything is Info
- Configuration: injected, parsed strings
- Dependencies: manually created, custom configured, lifetime not managed - DbContext
- Functionality: custom caching, custom mapping

> This is effectively a port of the WCF service, with all the same problems

### Better example 

This example uses standard .NET Core approaches which map to key best practices.

Controller - [CitiesController.cs](src/dotnet/WorldWideImporters/WorldWideImporters.Api/Controllers/CitiesController.cs)

- Logging: logger from DI, different levels
- Configuration: not used directly
- Dependencies: injected - mapper, cache, DbContext - lifetime controlled by DI
- Functionality: separate classes for caching and mapping

> Dependency injection makes unit testing easier and the class only has code that it needs, other features are in other classes

Dependency - [MemoryCache.cs](src/dotnet/WorldWideImporters/WorldWideImporters.Caching/MemoryCache.cs)

- Logging: none (considered as framework code)
- Configuration: injected, strongly-typed
- Dependencies: injected
- Functionality: clearly scoped, wrapper for Extensions cache

Dependency - [CachingOptions.cs](src/dotnet/WorldWideImporters/WorldWideImporters.Caching/Options/CachingOptions.cs)

- Configuration: settings loaded from [appsettings.json](src/dotnet/WorldWideImporters/WorldWideImporters.Api/appsettings.json) Extensions
- Functionality: typed config, default settings - standard support

Logging & Configuration - configured as standard in [Program.cs](src/dotnet/WorldWideImporters/WorldWideImporters.Api/Program.cs)

- Logging: multiple sinks supported, plus integration - e.g. Serilog
- Configuration: multiple sources merged, can customize order

Dependency Injection - standard service collecion in [Startup.cs](src/dotnet/WorldWideImporters/WorldWideImporters.Api/Startup.cs)

- Functionality: manages lifetimes, clean integration - e.g. AutoMapper

> The .NET Core approach favours conventions. That reduces code and the potential for errors, but it makes it hard to understand how things are wired up - until you get familiar with it.

### Other notes

References - [WorldWideImporters.Api.csproj](src/dotnet/WorldWideImporters/WorldWideImporters.Api/WorldWideImporters.Api.csproj)

- references set in project files
- external NuGet and local projects
- in VS be sure to use _Manage NuGet Packages for Solution_

Runtime -

- .NET Core is cross-platform, the same code can run on Linux or Windows
- ASP.NET Core provides its own web server; web apps run as console apps

Roadmap - [.NET Support Policy](https://dotnet.microsoft.com/platform/support/policy)

- .NET Core 3.1 is LTS with support until December 2022
- .NET 5 is the current release (drops "Core" name)
- .NET 6 coming in 2022 will be the next LTS