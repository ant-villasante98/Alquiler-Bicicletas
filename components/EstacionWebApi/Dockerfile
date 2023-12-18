FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source

COPY *.sln .
COPY src/WebApi/*.csproj ./src/WebApi/
COPY src/Domain/*.csproj ./src/Domain/
COPY src/Infrastructure/*.csproj ./src/Infrastructure/
COPY test/ ./test/
RUN dotnet restore

COPY . .
RUN dotnet publish ./src/WebApi/WebApi.csproj -o /out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /out ./
ENTRYPOINT ["dotnet","WebApi.dll"]
