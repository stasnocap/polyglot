FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/frontend/Polyglot.Server/Polyglot.Server.csproj", "src/frontend/Polyglot.Server/"]
COPY ["src/frontend/polyglot.client/polyglot.client.esproj", "src/frontend/polyglot.client/"]
RUN dotnet restore "src/frontend/Polyglot.Server/Polyglot.Server.csproj"
COPY . .
WORKDIR "/src/src/frontend/Polyglot.Server"
RUN dotnet build "Polyglot.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Polyglot.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Polyglot.Server.dll"]
