#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Beeline.QueryExporter/Beeline.QueryExporter.csproj", "Beeline.QueryExporter/"]
RUN dotnet restore "Beeline.QueryExporter/Beeline.QueryExporter.csproj"
COPY . .
WORKDIR "/src/Beeline.QueryExporter"
RUN dotnet build "Beeline.QueryExporter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Beeline.QueryExporter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Beeline.QueryExporter.dll"]