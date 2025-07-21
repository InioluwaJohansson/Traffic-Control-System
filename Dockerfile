# 1. Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy everything and restore dependencies
COPY . . 
RUN dotnet restore

# Build and publish in Release mode to the /out folder
RUN dotnet publish -c Release -o out

# 2. Use the smaller runtime image for the final container
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/out .

# Expose port 80 for Railway (you can also expose 443 if using HTTPS)
EXPOSE 443

# Start the app
ENTRYPOINT ["dotnet", "Traffic Control System.dll"]
