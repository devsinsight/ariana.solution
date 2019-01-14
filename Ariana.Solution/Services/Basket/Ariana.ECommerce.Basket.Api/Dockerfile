FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Services/Basket/Ariana.ECommerce.Basket.Api/Ariana.ECommerce.Basket.Api.csproj Services/Basket/Ariana.ECommerce.Basket.Api/
COPY Services/Basket/Ariana.ECommerce.Basket.Application/Ariana.ECommerce.Basket.Application.csproj Services/Basket/Ariana.ECommerce.Basket.Application/
COPY BuildingBlocks/Ariana.ECommerce.EventBus/Ariana.ECommerce.EventBus.csproj BuildingBlocks/Ariana.ECommerce.EventBus/
RUN dotnet restore Services/Basket/Ariana.ECommerce.Basket.Api/Ariana.ECommerce.Basket.Api.csproj
COPY . .
WORKDIR /src/Services/Basket/Ariana.ECommerce.Basket.Api
RUN dotnet build Ariana.ECommerce.Basket.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Ariana.ECommerce.Basket.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ariana.ECommerce.Basket.Api.dll"]
