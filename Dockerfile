# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore


# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Stage 2: Serve the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
 
#COPY init.sql /docker-entrypoint-initdb.d/

# Définir le point d'entrée du conteneur
ENTRYPOINT ["dotnet", "CafeDuCoin.dll"]
# Apply database migrations
#CMD ["dotnet", "ef", "database", "update", "--no-build", "--no-launch-profile"]

