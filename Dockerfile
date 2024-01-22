# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

# Set the working directory for backend
WORKDIR /app/Backend

# Copy the published backend files to the working directory
COPY Backend/publish/ .

# Use Node.js image as the base image for frontend build
FROM node:14 AS frontend-build

# Set the working directory for frontend
WORKDIR /app/Frontend/dist

# Copy the frontend project files to the working directory
COPY Frontend/dist/ .

# Run npm install and npm run build for the Vue.js frontend
RUN npm install

RUN npm run build

# Use a lighter runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the published backend files from the build image
COPY --from=build /app/Backend .

# Copy the built frontend files to the web server directory
COPY --from=frontend-build /app/Frontend/dist /app/wwwroot

# Expose port 80
EXPOSE 80

# Specify the command to run the backend application
CMD ["dotnet", "IMDB.dll"]  
