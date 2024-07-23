#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/RingoMedia.Migrator/RingoMedia.Migrator.csproj", "src/RingoMedia.Migrator/"]
COPY ["src/RingoMedia.EntityFrameworkCore/RingoMedia.EntityFrameworkCore.csproj", "src/RingoMedia.EntityFrameworkCore/"]
COPY ["src/RingoMedia.Core/RingoMedia.Core.csproj", "src/RingoMedia.Core/"]
COPY ["src/RingoMedia.Core.Shared/RingoMedia.Core.Shared.csproj", "src/RingoMedia.Core.Shared/"]
RUN dotnet restore "src/RingoMedia.Migrator/RingoMedia.Migrator.csproj"
COPY . .
WORKDIR "/src/src/RingoMedia.Migrator"
RUN dotnet build "RingoMedia.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RingoMedia.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RingoMedia.Migrator.dll", "-s"]
