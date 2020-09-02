FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine3.11 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.11 AS build
WORKDIR /src
COPY ["Take.Api.Media.Provider.Facades/Take.Api.Media.Provider.Facades.csproj", "Take.Api.Media.Provider.Facades/"]
COPY ["Take.Api.Media.Provider.Models/Take.Api.Media.Provider.Models.csproj", "Take.Api.Media.Provider.Models/"]
COPY ["Take.Api.Media.Provider.Services/Take.Api.Media.Provider.Services.csproj", "Take.Api.Media.Provider.Services/"]
COPY ["Take.Api.Media.Provider/Take.Api.Media.Provider.csproj", "Take.Api.Media.Provider/"]

RUN dotnet restore "Take.Api.Media.Provider/Take.Api.Media.Provider.csproj"
COPY . .
WORKDIR "/src/Take.Api.Media.Provider"
RUN dotnet build "Take.Api.Media.Provider.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Take.Api.Media.Provider.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Take.Api.Media.Provider.dll"]