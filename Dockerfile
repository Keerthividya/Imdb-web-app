# Stage 1: Build the .NET backend
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /app/Backend
COPY Backend/. .

RUN dotnet publish -c Release -o publish

# Stage 2: Build the Vue.js frontend
FROM node:14 AS frontend-build

WORKDIR /app/Frontend

COPY Frontend/package*.json ./
RUN npm install

COPY Frontend/ .

# Run npm install and npm run build for the Vue.js frontend
RUN npm install
RUN npm run build

# Stage 3: Build the final image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /app

# Copy the published .NET backend
COPY --from=build /app/Backend/publish .

# Copy the built Vue.js frontend to the web server directory
COPY --from=frontend-build /app/Frontend/dist /app/wwwroot

# Expose port 80
EXPOSE 80

# Specify the command to run the .NET backend application
CMD ["dotnet", "IMDB.dll"]
