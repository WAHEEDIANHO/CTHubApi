FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
#EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CThub.Api/CThub.Api.csproj", "CThub.Api/"]
COPY ["../CThub.Contract/CThub.Contract.csproj", "CThub.Contract/"]
COPY ["../CThub.Domain/CThub.Domain.csproj", "CThub.Domain/"]
COPY ["../CThub.Application/CThub.Application.csproj", "CThub.Application/"]
COPY ["../CThub.Infrastructure/CThub.Infrastructure.csproj", "CThub.Infrastructure/"]
#COPY *.csproj ./

RUN dotnet restore "CThub.Api/CThub.Api.csproj" --force
COPY . .
WORKDIR "/src/CThub.Api"
RUN ls
RUN dotnet build "CThub.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CThub.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CThub.Api.dll"]
EXPOSE 5125