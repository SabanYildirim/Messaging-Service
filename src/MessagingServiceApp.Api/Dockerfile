#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/MessagingServiceApp.Api/MessagingServiceApp.Api.csproj", "src/MessagingServiceApp.Api/"]
COPY ["src/MessagingServiceApp.Application/MessagingServiceApp.Application.csproj", "src/MessagingServiceApp.Application/"]
COPY ["src/MessagingServiceApp.Infrastructure/MessagingServiceApp.Infrastructure.csproj", "src/MessagingServiceApp.Infrastructure/"]
COPY ["src/MessagingServiceApp.Common/MessagingServiceApp.Common.csproj", "src/MessagingServiceApp.Common/"]
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