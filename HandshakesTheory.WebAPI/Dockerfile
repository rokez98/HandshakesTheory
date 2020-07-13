FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["HandshakesTheory.WebAPI/HandshakesTheory.WebAPI.csproj", "HandshakesTheory.WebAPI/"]
COPY ["HandshakesTheory.VkModel/HandshakesTheory.VkModel.csproj", "HandshakesTheory.VkModel/"]
COPY ["HandshakesTheory.GraphLibrary/HandshakesTheory.GraphLibrary.csproj", "HandshakesTheory.GraphLibrary/"]
RUN dotnet restore "HandshakesTheory.WebAPI/HandshakesTheory.WebAPI.csproj"
COPY . .
WORKDIR "/src/HandshakesTheory.WebAPI"
RUN dotnet build "HandshakesTheory.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HandshakesTheory.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HandshakesTheory.WebAPI.dll"]