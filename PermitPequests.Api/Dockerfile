#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PermitPequests.Api/PermitPequests.Api.csproj", "PermitPequests.Api/"]
RUN dotnet restore "PermitPequests.Api/PermitPequests.Api.csproj"
COPY . .
WORKDIR "/src/PermitPequests.Api"
RUN dotnet build "PermitPequests.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PermitPequests.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PermitPequests.Api.dll"]