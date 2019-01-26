FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Services/a/WebApplication1/WebApplication1.csproj", "Services/a/WebApplication1/"]
RUN dotnet restore "Services/a/WebApplication1/WebApplication1.csproj"
COPY . .
WORKDIR "/src/Services/a/WebApplication1"
RUN dotnet build "WebApplication1.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebApplication1.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApplication1.dll"]