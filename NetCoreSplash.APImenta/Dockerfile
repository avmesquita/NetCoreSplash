#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 2461
EXPOSE 7852

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["NetCoreSplash.APImenta/NetCoreSplash.APImenta.csproj", "NetCoreSplash.APImenta/"]
RUN dotnet restore "NetCoreSplash.APImenta/NetCoreSplash.APImenta.csproj"
COPY . .
WORKDIR "/src/NetCoreSplash.APImenta"
RUN dotnet build "NetCoreSplash.APImenta.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCoreSplash.APImenta.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCoreSplash.APImenta.dll"]