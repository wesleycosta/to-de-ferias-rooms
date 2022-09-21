FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore "src/ToDeFerias.Rooms.sln" && dotnet build "src/ToDeFerias.Rooms.sln" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/ToDeFerias.Rooms.Api/ToDeFerias.Rooms.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDeFerias.Rooms.Api.dll"]