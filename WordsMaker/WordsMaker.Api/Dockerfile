#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["WordsMaker.Api/WordsMaker.Api.csproj", "WordsMaker.Api/"]
RUN dotnet restore "WordsMaker.Api/WordsMaker.Api.csproj"
COPY . .
WORKDIR "/src/WordsMaker.Api"
RUN dotnet build "WordsMaker.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WordsMaker.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WordsMaker.Api.dll"]



FROM ubuntu:20.04
# Ustaw zmienne œrodowiskowe dla SQL Server
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=TwojeHaslo123
# Dodaj repozytorium Microsoft SQL Server do systemu
RUN apt-get update && \
    apt-get install -y wget && \
    wget -qO- https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    echo "deb [arch=amd64] https://packages.microsoft.com/ubuntu/20.04/mssql-server-2019/ stable main" > /etc/apt/sources.list.d/mssql-server.list && \
    apt-get update && \
    apt-get install -y mssql-server

# Skonfiguruj SQL Server i uruchom go
RUN /opt/mssql/bin/mssql-conf setup accept-eula && \
    service mssql-server start

# Otwórz porty na których dzia³a SQL Server (standardowe porty to 1433)
EXPOSE 1433