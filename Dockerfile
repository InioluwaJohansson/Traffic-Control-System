# Use the official .NET 6 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy .csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Use a lighter runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Expose port 80 for Railway (you can also expose 443 if using HTTPS)
EXPOSE 443

# Start the app
ENTRYPOINT ["dotnet", "Traffic Control System.dll"]
