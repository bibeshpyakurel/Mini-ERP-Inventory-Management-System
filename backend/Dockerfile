FROM mcr.microsoft.com/dotnet/sdk:9.0

WORKDIR /app

COPY backend/src/MiniErp.Domain/MiniErp.Domain.csproj backend/src/MiniErp.Domain/
COPY backend/src/MiniErp.Application/MiniErp.Application.csproj backend/src/MiniErp.Application/
COPY backend/src/MiniErp.Infrastructure/MiniErp.Infrastructure.csproj backend/src/MiniErp.Infrastructure/
COPY backend/src/MiniErp.Api/MiniErp.Api.csproj backend/src/MiniErp.Api/

RUN dotnet restore backend/src/MiniErp.Api/MiniErp.Api.csproj

COPY backend ./backend

WORKDIR /app/backend/src/MiniErp.Api

EXPOSE 5000

CMD ["dotnet", "run", "--project", "MiniErp.Api.csproj", "--urls", "http://0.0.0.0:5000"]
