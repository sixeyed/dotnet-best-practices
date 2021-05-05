# .NET Best Practices

## Demo 3: .NET Apps in Docker

Build and run the WCF and WebAPI components in Windows containers.

### Pre-reqs

[Docker Desktop](https://www.docker.com/products/docker-desktop) running on Windows.

### Dockerfiles

- [WCF app](docker/wwi-svc/Dockerfile)

- [Web API](docker/wwi-api/Dockerfile)

### Docker Compose spec

- [Database, WCF & Web API](docker-compose.yml)

### Build & run

_In Windows Container mode_

Build:

```
docker-compose build
```

Check images:

```
docker image ls sixeyed/wwi*
```

Run:

```
docker-compose up -d
```

Check containers:

```
docker ps
```

### Test

- WCF Test client using http://localhost:8080

- Postman using http://localhost:8088

Check logs:

```
docker logs dotnet-best-practices_wwi-api_1

docker logs dotnet-best-practices_wwi-svc_1
```