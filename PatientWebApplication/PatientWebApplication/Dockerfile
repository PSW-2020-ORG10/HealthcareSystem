#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
WORKDIR /app
COPY . .
EXPOSE 80
CMD ASPNETCORE_URLS=http://*:$PORT dotnet PatientWebApplication.dll