# tools
FROM mcr.microsoft.com/windows/nanoserver:1809 AS logmonitor
ARG LOGMONITOR_VERSION="v1.1"
ADD https://github.com/microsoft/windows-container-tools/releases/download/${LOGMONITOR_VERSION}/LogMonitor.exe .

# builder
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8-windowsservercore-ltsc2019 AS builder

WORKDIR /src
COPY src/netfx/WideWorldImporters/WideWorldImporters.sln .
COPY src/netfx/WideWorldImporters/ReferencedAssemblies/ ./ReferencedAssemblies/
COPY src/netfx/WideWorldImporters/WideWorldImporters.Data/WideWorldImporters.Data.csproj ./WideWorldImporters.Data/
COPY src/netfx/WideWorldImporters/WideWorldImporters.Data/packages.config ./WideWorldImporters.Data/
COPY src/netfx/WideWorldImporters/WideWorldImporters.Services/WideWorldImporters.Services.csproj ./WideWorldImporters.Services/
COPY src/netfx/WideWorldImporters/WideWorldImporters.Services/packages.config ./WideWorldImporters.Services/
RUN nuget restore WideWorldImporters.sln

COPY src/netfx/WideWorldImporters/ .
RUN msbuild WideWorldImporters.Services/WideWorldImporters.Services.csproj /p:OutputPath=c:/out

# app
FROM mcr.microsoft.com/dotnet/framework/wcf:4.8-windowsservercore-ltsc2019

ENV APP_ROOT=C:\\inetpub\\wwwroot \
    LOGS_ROOT=C:\\logs

ENTRYPOINT C:\\LogMonitor.exe C:\\ServiceMonitor.exe w3svc

COPY --from=logmonitor /LogMonitor.exe /LogMonitor.exe
COPY --from=builder /out/_PublishedWebsites/WideWorldImporters.Services ${APP_ROOT} 

COPY docker/wwi-svc/LogMonitorConfig.json /LogMonitor/
COPY docker/wwi-svc/Web.config ${APP_ROOT}
COPY docker/wwi-svc/config/*.config ${APP_ROOT}/config/