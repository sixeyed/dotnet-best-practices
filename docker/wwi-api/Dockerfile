FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as builder

WORKDIR /src
COPY src/dotnet/WorldWideImporters/WorldWideImporters.Caching/WorldWideImporters.Caching.csproj ./WorldWideImporters.Caching/
COPY src/dotnet/WorldWideImporters/WorldWideImporters.Data/WorldWideImporters.Data.csproj ./WorldWideImporters.Data/
COPY src/dotnet/WorldWideImporters/WorldWideImporters.Model/WorldWideImporters.Model.csproj ./WorldWideImporters.Model/
COPY src/dotnet/WorldWideImporters/WorldWideImporters.Mapping/WorldWideImporters.Mapping.csproj ./WorldWideImporters.Mapping/
COPY src/dotnet/WorldWideImporters/WorldWideImporters.Api/WorldWideImporters.Api.csproj ./WorldWideImporters.Api/

WORKDIR /src/WorldWideImporters.Api
RUN dotnet restore

COPY src/dotnet/WorldWideImporters/ /src
RUN dotnet publish -c Release -o /out --no-restore WorldWideImporters.Api.csproj

# app image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

ENV APP_ROOT=/app
WORKDIR ${APP_ROOT}
EXPOSE 80
ENTRYPOINT ["dotnet", "/app/WorldWideImporters.Api.dll"]

COPY --from=builder /out/ ${APP_ROOT}/

COPY docker/wwi-api/config/*.json ${APP_ROOT}/config/
COPY docker/wwi-api/secrets/*.json ${APP_ROOT}/secrets/