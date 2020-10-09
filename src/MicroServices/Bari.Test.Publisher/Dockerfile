#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/MicroServices/Bari.Test.Publisher/Bari.Test.Publisher.csproj", "src/MicroServices/Bari.Test.Publisher/"]
COPY ["src/Domain/Bari.Test.Domain.Core/Bari.Test.Domain.Core.csproj", "src/Domain/Bari.Test.Domain.Core/"]
RUN dotnet restore "src/MicroServices/Bari.Test.Publisher/Bari.Test.Publisher.csproj"
COPY . .
WORKDIR "/src/src/MicroServices/Bari.Test.Publisher"
RUN dotnet build "Bari.Test.Publisher.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bari.Test.Publisher.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bari.Test.Publisher.dll"]