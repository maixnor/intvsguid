FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["JoinPerformanceTests/JoinPerformanceTests.csproj", "JoinPerformanceTests/"]
RUN dotnet restore "JoinPerformanceTests/JoinPerformanceTests.csproj"
COPY . .
WORKDIR "/src/JoinPerformanceTests"
RUN dotnet build "JoinPerformanceTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JoinPerformanceTests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JoinPerformanceTests.dll"]
