# Use the official .NET SDK image as the base image for building the backend
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

# Set the working directory for the backend build
WORKDIR /src

# Copy the backend project files to the working directory
COPY Backend/ .

# Restore, build, and publish the backend project
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Use Node.js image as the base image for frontend build
FROM node:14 AS frontend-build

# Set the working directory for frontend build
WORKDIR /app

# Copy the frontend project files to the working directory
COPY Frontend/ .

# Install dependencies and build the Vue.js frontend
RUN npm install
RUN npm run build

# Use a lighter runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the published backend files from the build image
COPY --from=build /app/publish .

# Copy the built frontend files from the frontend-build image
COPY --from=frontend-build /app/dist /app/wwwroot

# Expose port 80
EXPOSE 80

# Specify the command to run the backend application
CMD ["dotnet", "IMDB.dll"]
