# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS builder
WORKDIR /app

COPY backend/src/MiniErp.Domain/MiniErp.Domain.csproj src/MiniErp.Domain/
COPY backend/src/MiniErp.Application/MiniErp.Application.csproj src/MiniErp.Application/
COPY backend/src/MiniErp.Infrastructure/MiniErp.Infrastructure.csproj src/MiniErp.Infrastructure/
COPY backend/src/MiniErp.Api/MiniErp.Api.csproj src/MiniErp.Api/

RUN dotnet restore src/MiniErp.Api/MiniErp.Api.csproj

COPY backend/src ./src

RUN dotnet publish src/MiniErp.Api/MiniErp.Api.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=builder /app/publish .
EXPOSE 5000
ENV ASPNETCORE_URLS=http://0.0.0.0:5000
CMD ["dotnet", "MiniErp.Api.dll"]
