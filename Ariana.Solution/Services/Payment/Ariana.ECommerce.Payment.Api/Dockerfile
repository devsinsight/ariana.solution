FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Ariana.ECommerce.Payment.Api/Ariana.ECommerce.Payment.Api.csproj", "Ariana.ECommerce.Payment.Api/"]
RUN dotnet restore "Ariana.ECommerce.Payment.Api/Ariana.ECommerce.Payment.Api.csproj"
COPY . .
WORKDIR "/src/Ariana.ECommerce.Payment.Api"
RUN dotnet build "Ariana.ECommerce.Payment.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Ariana.ECommerce.Payment.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ariana.ECommerce.Payment.Api.dll"]