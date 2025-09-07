# PropostaService Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore ./Adapters/In/Api/PropostaService.Api.csproj
RUN dotnet publish ./Adapters/In/Api/PropostaService.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PropostaService.Api.dll"]