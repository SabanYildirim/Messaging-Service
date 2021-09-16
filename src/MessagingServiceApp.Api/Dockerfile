#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/MessagingServiceApp.Api/MessagingServiceApp.Api.csproj", "src/MessagingServiceApp.Api/"]
RUN dotnet restore "src/MessagingServiceApp.Api/MessagingServiceApp.Api.csproj"
COPY . .
WORKDIR "/src/src/MessagingServiceApp.Api"
RUN dotnet build "MessagingServiceApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MessagingServiceApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MessagingServiceApp.Api.dll"]