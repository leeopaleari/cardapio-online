FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
RUN apk add --no-cache icu-libs icu-data-full
EXPOSE 3333

ENV ASPNETCORE_URLS=http://+:3333
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV ConnectionStrings:DatabaseConnection=server=mysql;database=Cardapio;user=root;password=1232

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src

COPY ["./API/API.csproj", "src/API/"]
COPY ["./Application/Application.csproj", "src/Application/"]
COPY ["./Domain/Domain.csproj", "src/Domain/"]
COPY ["./Infra.Data/Infra.Data.csproj", "src/Infra.Data/"]
COPY ["./Infra.Ioc/Infra.Ioc.csproj", "src/Infra.Ioc/"]

RUN dotnet restore "src/API/API.csproj"

COPY . .

WORKDIR "/src/API/"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS runtime
WORKDIR /app

COPY --from=publish /app/publish .
RUN ls -l
ENTRYPOINT ["dotnet", "API.dll"]