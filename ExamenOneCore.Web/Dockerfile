FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ExamenOneCore.Web/ExamenOneCore.Web.csproj ExamenOneCore.Web/
COPY ExamenOneCore.Entitie/ExamenOneCore.Entity.csproj ExamenOneCore.Entitie/
RUN dotnet restore ExamenOneCore.Web/ExamenOneCore.Web.csproj
COPY . .
WORKDIR /src/ExamenOneCore.Web
RUN dotnet build ExamenOneCore.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ExamenOneCore.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ExamenOneCore.Web.dll"]
