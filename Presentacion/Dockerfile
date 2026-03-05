FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiar toda la solución
COPY .. .

# Entrar a Presentacion
WORKDIR /src/Presentacion

RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Presentacion.dll"]