#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Bougle.French.Glaff.Web/Bougle.French.Glaff.Web.csproj", "Bougle.French.Glaff.Web/"]
COPY ["Bougle.French.Glaff.Contracts/Bougle.French.Glaff.Contracts.csproj", "Bougle.French.Glaff.Contracts/"]
COPY ["Bougle.French.Glaff.Storage/Bougle.French.Glaff.Storage.csproj", "Bougle.French.Glaff.Storage/"]
RUN dotnet restore "Bougle.French.Glaff.Web/Bougle.French.Glaff.Web.csproj"
COPY . .
WORKDIR "/src/Bougle.French.Glaff.Web"
RUN dotnet build "Bougle.French.Glaff.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bougle.French.Glaff.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bougle.French.Glaff.Web.dll"]
