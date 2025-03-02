# Frontend build stage
FROM node:20-slim as frontend-build

WORKDIR /app

# Copy package files
COPY package*.json ./

# Install dependencies
RUN npm ci

# Copy source files
COPY . .

# Build the application
RUN npm run build

# Backend build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS backend-build
WORKDIR /src
COPY ChatApi/*.csproj ./
RUN dotnet restore
COPY ChatApi/. .
RUN dotnet publish -c Release -o /app/publish

# Final stage
FROM nginx:alpine

# Copy frontend static files
COPY --from=frontend-build /app/dist /usr/share/nginx/html

# Copy nginx configuration
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Install .NET runtime
RUN apk add --no-cache aspnetcore-runtime-8.0

# Copy backend files
COPY --from=backend-build /app/publish /app

# Expose port 80
EXPOSE 80

# Start both Nginx and the .NET application
COPY start.sh /start.sh
RUN chmod +x /start.sh
CMD ["/start.sh"] 