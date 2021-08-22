#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DeliVeggieApp.APIGateway/DeliVeggieApp.APIGateway.csproj", "DeliVeggieApp.APIGateway/"]
COPY ["DeliVeggieApp.Infrastructure.Messaging/DeliVeggieApp.Infrastructure.Messaging.csproj", "DeliVeggieApp.Infrastructure.Messaging/"]
COPY ["DeliVeggieApp.BuildingBlocks/DeliVeggieApp.Infrastructure.BuildingBlocks.csproj", "DeliVeggieApp.BuildingBlocks/"]
RUN dotnet restore "DeliVeggieApp.APIGateway/DeliVeggieApp.APIGateway.csproj"
COPY . .
WORKDIR "/src/DeliVeggieApp.APIGateway"
RUN dotnet build "DeliVeggieApp.APIGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeliVeggieApp.APIGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeliVeggieApp.APIGateway.dll"]
