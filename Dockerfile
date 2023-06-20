FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NAGPDemoWebAPI/NAGPDemoWebAPI.csproj", "NAGPDemoWebAPI/"]
RUN dotnet restore "NAGPDemoWebAPI/NAGPDemoWebAPI.csproj"
COPY . .
WORKDIR "/src/NAGPDemoWebAPI"
RUN dotnet build "NAGPDemoWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NAGPDemoWebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NAGPDemoWebAPI.dll"]
