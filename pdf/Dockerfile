# Use .NET 6 SDK to build the project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app

# Yahan folder create karo
RUN mkdir -p /app/UploadedFiles

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "PDF_Uploading.dll"]
