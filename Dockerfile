# Use the official .NET SDK image as the base image for backend build
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS backend-build

# Set the working directory for backend
WORKDIR /app/Backend

# Copy the backend project files to the working directory
COPY Backend/ .

# Build the backend application
RUN dotnet publish -c Release -o out

# Use Node.js image as the base image for frontend build
FROM node:14 AS frontend-build

# Set the working directory for frontend
WORKDIR /app/Frontend

# Copy the frontend project files to the working directory
COPY Frontend/ .

# Install dependencies and build the frontend application
RUN npm install
RUN npm run build

# Use a lighter runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the published backend files from the build image
COPY --from=backend-build /app/Backend/out .

# Copy the built frontend files to the webserver directory
COPY --from=frontend-build /app/Frontend/dist /app/wwwroot

# Expose port 80
EXPOSE 80

# Specify the command to run the backend application
CMD ["dotnet", "YourBackendApp.dll"]
