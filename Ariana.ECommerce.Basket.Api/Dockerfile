FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Ariana.ECommerce.Basket.Api/Ariana.ECommerce.Basket.Api.csproj Ariana.ECommerce.Basket.Api/
RUN dotnet restore Ariana.ECommerce.Basket.Api/Ariana.ECommerce.Basket.Api.csproj
COPY . .
WORKDIR /src/Ariana.ECommerce.Basket.Api
RUN dotnet build Ariana.ECommerce.Basket.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Ariana.ECommerce.Basket.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ariana.ECommerce.Basket.Api.dll"]
