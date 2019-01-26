FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Services/Catalog/Ariana.ECommerce.Catalog.Api/Ariana.ECommerce.Catalog.Api.csproj Services/Catalog/Ariana.ECommerce.Catalog.Api/
COPY Services/Catalog/Ariana.ECommerce.Catalog.Application/Ariana.ECommerce.Catalog.Application.csproj Services/Catalog/Ariana.ECommerce.Catalog.Application/
COPY Services/Catalog/Ariana.ECommerce.Catalog.Repository/Ariana.ECommerce.Catalog.Repository.csproj Services/Catalog/Ariana.ECommerce.Catalog.Repository/
COPY Services/Catalog/Ariana.ECommerce.Catalog.Domain/Ariana.ECommerce.Catalog.Domain.csproj Services/Catalog/Ariana.ECommerce.Catalog.Domain/
COPY BuildingBlocks/Ariana.ECommerce.EventBus/Ariana.ECommerce.EventBus.csproj BuildingBlocks/Ariana.ECommerce.EventBus/
RUN dotnet restore Services/Catalog/Ariana.ECommerce.Catalog.Api/Ariana.ECommerce.Catalog.Api.csproj
COPY . .
WORKDIR /src/Services/Catalog/Ariana.ECommerce.Catalog.Api
RUN dotnet build Ariana.ECommerce.Catalog.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Ariana.ECommerce.Catalog.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ariana.ECommerce.Catalog.Api.dll"]
