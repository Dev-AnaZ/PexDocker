# Estágio 1: Build (Compilação)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia o arquivo de projeto e restaura os pacotes (NuGet)
COPY ["DevCostAPI.csproj", "./"]
RUN dotnet restore "./DevCostAPI.csproj"

# Copia todo o resto do código e publica
COPY . .
RUN dotnet publish "DevCostAPI.csproj" -c Release -o /app/publish

# Estágio 2: Runtime (Execução Leve)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DevCostAPI.dll"]