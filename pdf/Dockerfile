# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app/out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# 👇 Railway crash se bachne ke liye folder pehle bana do
RUN mkdir -p /app/UploadedFiles

COPY --from=build /app/out ./

# 👇 Railway default port expose karo
EXPOSE 8080

ENTRYPOINT ["dotnet", "pdf.dll"]
