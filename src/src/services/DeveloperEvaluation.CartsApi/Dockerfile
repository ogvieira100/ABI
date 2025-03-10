#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5077


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/DeveloperEvaluation.CartsApi/DeveloperEvaluation.CartsApi.csproj", "services/DeveloperEvaluation.CartsApi/"]
COPY ["building-blocks/DeveloperEvaluation.Core/DeveloperEvaluation.Core.csproj", "building-blocks/DeveloperEvaluation.Core/"]
COPY ["building-blocks/DeveloperEvaluation.MessageBus/DeveloperEvaluation.MessageBus.csproj", "building-blocks/DeveloperEvaluation.MessageBus/"]
RUN dotnet restore "services/DeveloperEvaluation.CartsApi/DeveloperEvaluation.CartsApi.csproj"
COPY . .
WORKDIR "services/DeveloperEvaluation.CartsApi"
RUN dotnet build "DeveloperEvaluation.CartsApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeveloperEvaluation.CartsApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeveloperEvaluation.CartsApi.dll"]