# Use the official .NET runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 4200

# Use SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WhatsUpMon.Api.csproj", "./"]
RUN dotnet restore "WhatsUpMon.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WhatsUpMon.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WhatsUpMon.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WhatsUpMon.Api.dll"]
