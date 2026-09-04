FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["AbujalWebsite.csproj", "./"]
RUN dotnet restore "AbujalWebsite.csproj"

COPY . .
RUN dotnet publish "AbujalWebsite.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

EXPOSE 8080

RUN addgroup --system app && adduser --system --ingroup app app

COPY --from=build /app/publish .
USER app

ENTRYPOINT ["sh", "-c", "export ASPNETCORE_URLS=http://0.0.0.0:${PORT:-8080}; dotnet AbujalWebsite.dll"]
