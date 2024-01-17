FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source

COPY *.sln .
COPY src/Estaciones.Application/*.csproj ./src/Estaciones.Application/
COPY src/Estaciones.Domain/*.csproj ./src/Estaciones.Domain/
COPY src/Estaciones.Infrastructure/*.csproj ./src/Estaciones.Infrastructure/
COPY WebApi/*.csproj WebApi/
COPY test/ ./test/
RUN dotnet restore

COPY . .
RUN dotnet publish ./WebApi/WebApi.csproj -o /out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /out ./
ENTRYPOINT ["dotnet","WebApi.dll"]
