FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["HandshakesTheory.Site/HandshakesTheory.Site.csproj", "HandshakesTheory.Site/"]
RUN curl --silent --location https://deb.nodesource.com/setup_12.x | bash -
RUN apt-get install --yes nodejs
RUN dotnet restore "HandshakesTheory.Site/HandshakesTheory.Site.csproj"
COPY . .
WORKDIR "/src/HandshakesTheory.Site"
RUN dotnet build "HandshakesTheory.Site.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HandshakesTheory.Site.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "HandshakesTheory.Site.dll"]
