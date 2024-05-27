FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["restaurant_managemant/restaurant_managemant.csproj", "restaurant_managemant/"]
RUN dotnet restore "restaurant_managemant/restaurant_managemant.csproj"
COPY . .
WORKDIR "/src/restaurant_managemant"
RUN dotnet build "restaurant_managemant.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "restaurant_managemant.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "restaurant_managemant.dll"]
