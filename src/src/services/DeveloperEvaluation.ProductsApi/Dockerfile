#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/DeveloperEvaluation.ProductsApi/DeveloperEvaluation.ProductsApi.csproj", "services/DeveloperEvaluation.ProductsApi/"]
COPY ["building-blocks/DeveloperEvaluation.Core/DeveloperEvaluation.Core.csproj", "building-blocks/DeveloperEvaluation.Core/"]
COPY ["building-blocks/DeveloperEvaluation.MessageBus/DeveloperEvaluation.MessageBus.csproj", "building-blocks/DeveloperEvaluation.MessageBus/"]
RUN dotnet restore "services/DeveloperEvaluation.ProductsApi/DeveloperEvaluation.ProductsApi.csproj"
COPY . .
WORKDIR "services/DeveloperEvaluation.ProductsApi"
RUN dotnet build "DeveloperEvaluation.ProductsApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeveloperEvaluation.ProductsApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeveloperEvaluation.ProductsApi.dll"]