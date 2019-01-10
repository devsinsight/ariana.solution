FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Ariana.ECommerce.Catalog.Api/Ariana.ECommerce.Catalog.Api.csproj Ariana.ECommerce.Catalog.Api/
RUN dotnet restore Ariana.ECommerce.Catalog.Api/Ariana.ECommerce.Catalog.Api.csproj
COPY . .
WORKDIR /src/Ariana.ECommerce.Catalog.Api
RUN dotnet build Ariana.ECommerce.Catalog.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Ariana.ECommerce.Catalog.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ariana.ECommerce.Catalog.Api.dll"]
