#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/api/Ecommerce.Api/Ecommerce.Api.csproj", "src/api/Ecommerce.Api/"]
COPY ["src/core/Ecommerce.Application/Ecommerce.Application.csproj", "src/core/Ecommerce.Application/"]
COPY ["src/core/Ecommerce.Domain/Ecommerce.Domain.csproj", "src/core/Ecommerce.Domain/"]
COPY ["src/infrastructure/Ecommerce.infrastructure/Ecommerce.infrastructure.csproj", "src/infrastructure/Ecommerce.infrastructure/"]
COPY ["src/infrastructure/Ecommerce.Presistance/Ecommerce.Presistance.csproj", "src/infrastructure/Ecommerce.Presistance/"]
RUN dotnet restore "./src/api/Ecommerce.Api/Ecommerce.Api.csproj"
COPY . .
WORKDIR "/src/src/api/Ecommerce.Api"
RUN dotnet build "./Ecommerce.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ecommerce.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce.Api.dll"]