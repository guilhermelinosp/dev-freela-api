FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Source/DevFreela.API/DevFreela.API.csproj", "Source/DevFreela.API/"]
COPY ["Source/DevFreela.Application/DevFreela.Application.csproj", "Source/DevFreela.Application/"]
COPY ["Source/DevFreela.Domain/DevFreela.Domain.csproj", "Source/DevFreela.Domain/"]
COPY ["Source/DevFreela.Infrastructure/DevFreela.Infrastructure.csproj", "Source/DevFreela.Infrastructure/"]
RUN dotnet restore "Source/DevFreela.API/DevFreela.API.csproj"
COPY . .
WORKDIR "/src/Source/DevFreela.API"
RUN dotnet build "DevFreela.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DevFreela.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevFreela.API.dll"]
