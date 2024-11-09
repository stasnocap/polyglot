FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Polyglot.Web/Polyglot.Web.csproj", "src/Polyglot.Web/"]
COPY ["src/Polyglot.Application/Polyglot.Application.csproj", "src/Polyglot.Application/"]
COPY ["src/Polyglot.Domain/Polyglot.Domain.csproj", "src/Polyglot.Domain/"]
COPY ["src/Polyglot.Infrastructure/Polyglot.Infrastructure.csproj", "src/Polyglot.Infrastructure/"]
COPY ["src/polyglot.client/polyglot.client.esproj", "src/polyglot.client/"]
RUN dotnet restore "src/Polyglot.Web/Polyglot.Web.csproj"
COPY . .
WORKDIR "/src/src/Polyglot.Web"
RUN dotnet build "Polyglot.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Polyglot.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Polyglot.Web.dll"]
