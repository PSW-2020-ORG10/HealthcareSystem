#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
RUN curl -sL https://deb.nodesource.com/setup_12.x |  bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
RUN curl -sL https://deb.nodesource.com/setup_12.x |  bash -
RUN apt-get install -y nodejs
WORKDIR /src
COPY ["IntegrationWithPharmacies.csproj", ""]
RUN dotnet restore "IntegrationWithPharmacies.csproj"
COPY . .
WORKDIR "/src"
COPY front/package.json ./
COPY front/package-lock.json ./

RUN dotnet build "IntegrationWithPharmacies.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IntegrationWithPharmacies.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IntegrationWithPharmacies.dll"]