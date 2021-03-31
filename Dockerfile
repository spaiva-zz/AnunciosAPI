FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env

WORKDIR /app

COPY Anuncios.Domain/*.csproj Anuncios.Domain/
COPY Anuncios.Infra.Data/*.csproj Anuncios.Infra.Data/
COPY Anuncios.Infra.IOC/*.csproj Anuncios.Infra.IOC/
COPY Anuncios.Service.API/*.csproj Anuncios.Service.API/
COPY Anuncios.Application/*.csproj Anuncios.Application/
RUN dotnet restore ./Anuncios.Service.API/Anuncios.Service.API.csproj

COPY . ./
RUN dotnet publish ./Anuncios.Service.API -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "Anuncios.Service.API.dll"]