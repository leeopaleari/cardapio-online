FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
RUN mkdir -p /src
RUN apk add --no-cache icu-libs icu-data-full
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
#ENV ConnectionStrings:DatabaseConnection=server=mysql;database=Cardapio;user=root;password=1232

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src

COPY ["./API/API.csproj", "./API/"]
COPY ["./Application/Application.csproj", "./Application/"]
COPY ["./Domain/Domain.csproj", "./Domain/"]
COPY ["./Infra.Data/Infra.Data.csproj", "./Infra.Data/"]
COPY ["./Infra.Ioc/Infra.Ioc.csproj", "./Infra.Ioc/"]

RUN dotnet restore "./API/API.csproj"

COPY . .

WORKDIR "/src/API/"
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS runtime
WORKDIR /app

COPY --from=publish /app .
RUN ls -l
ENTRYPOINT ["dotnet", "API.dll"]