#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Sapfi.Api/Sapfi.Api.csproj", "Sapfi.Api/"]
RUN dotnet restore "Sapfi.Api/Sapfi.Api.csproj"
COPY . .
WORKDIR "/src/Sapfi.Api"
RUN dotnet build "Sapfi.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sapfi.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sapfi.Api.dll"]