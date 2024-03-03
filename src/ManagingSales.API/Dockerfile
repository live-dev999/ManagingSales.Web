#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/ManagingSales.API/ManagingSales.API.csproj", "src/ManagingSales.API/"]
COPY ["src/ManagingSales.Data/ManagingSales.Data.csproj", "src/ManagingSales.Data/"]
COPY ["src/ManagingSales.Business/ManagingSales.Business.csproj", "src/ManagingSales.Business/"]
COPY ["src/ManagingSales.Impl/ManagingSales.Impl.csproj", "src/ManagingSales.Impl/"]
RUN dotnet restore "src/ManagingSales.API/ManagingSales.API.csproj"
COPY . .
WORKDIR "/src/src/ManagingSales.API"
RUN dotnet build "ManagingSales.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ManagingSales.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ManagingSales.API.dll"]
