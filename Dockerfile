FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=${BUILD_CONFIGURATION:-Release}
WORKDIR /src
COPY ./APMApi.csproj .
RUN dotnet restore "APMApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "APMApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=${BUILD_CONFIGURATION:-Release}
RUN dotnet publish "APMApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APMApi.dll"]
