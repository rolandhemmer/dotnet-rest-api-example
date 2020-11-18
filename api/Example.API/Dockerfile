# ---- Build image ----
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine as build

WORKDIR /src

ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true

# Restore
COPY *.csproj ./Example.API/
RUN dotnet restore ./Example.API/*.csproj

# Sources
COPY . ./Example.API/

# Build
RUN dotnet publish ./Example.API/*.csproj -c Release -o /app

# ---- Runtime image ----
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine

WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true

# SOURCES
COPY --from=build /app .

EXPOSE 8080
CMD ["dotnet", "Example.API.dll"]
