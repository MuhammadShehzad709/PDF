# STEP 1: Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy .csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy all source code and build it
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# STEP 2: Runtime Image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Copy build output from previous stage
COPY --from=build /app/publish ./

# Start the app
ENTRYPOINT ["dotnet", "PDF.dll"]
