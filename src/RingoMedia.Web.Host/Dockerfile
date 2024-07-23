#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/RingoMedia.Web.Host/RingoMedia.Web.Host.csproj", "src/RingoMedia.Web.Host/"]
COPY ["src/RingoMedia.Web.Core/RingoMedia.Web.Core.csproj", "src/RingoMedia.Web.Core/"]
COPY ["src/RingoMedia.Application/RingoMedia.Application.csproj", "src/RingoMedia.Application/"]
COPY ["src/RingoMedia.Application.Shared/RingoMedia.Application.Shared.csproj", "src/RingoMedia.Application.Shared/"]
COPY ["src/RingoMedia.Core.Shared/RingoMedia.Core.Shared.csproj", "src/RingoMedia.Core.Shared/"]
COPY ["src/RingoMedia.Core/RingoMedia.Core.csproj", "src/RingoMedia.Core/"]
COPY ["src/RingoMedia.EntityFrameworkCore/RingoMedia.EntityFrameworkCore.csproj", "src/RingoMedia.EntityFrameworkCore/"]
COPY ["src/RingoMedia.GraphQL/RingoMedia.GraphQL.csproj", "src/RingoMedia.GraphQL/"]
RUN dotnet restore "src/RingoMedia.Web.Host/RingoMedia.Web.Host.csproj"
COPY . .
WORKDIR "/src/src/RingoMedia.Web.Host"
RUN dotnet build "RingoMedia.Web.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RingoMedia.Web.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RingoMedia.Web.Host.dll"]
