#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/ManagingSales.App/ManagingSales.App.csproj", "src/ManagingSales.App/"]
# COPY ["src/ManagingSales.App/nginx.conf", "src/ManagingSales.App/"]
RUN dotnet restore "src/ManagingSales.App/ManagingSales.App.csproj"
COPY . .
WORKDIR "/src/src/ManagingSales.App"
RUN dotnet build "ManagingSales.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ManagingSales.App.csproj" -c Release -o /app/publish /p:UseAppHost=false


# FROM nginx:alpine
# WORKDIR /var/www/web
# COPY --from=build-env /app/output/wwwroot .
# COPY nginx.conf /etc/nginx/nginx.conf
# EXPOSE 80

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

COPY --from=publish /app/publish/wwwroot .
COPY ["src/ManagingSales.App/nginx.conf", "/etc/nginx/nginx.conf"]