# Use the official .NET SDK image as a base image
FROM mcr.microsoft.com/dotnet/sdk:8.0

# Install additional system dependencies if needed
RUN apt-get update && apt-get install -y \
    git \
    iputils-ping \
    curl \
    dnsutils \
    net-tools \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /workspace

# Keep the container running
CMD ["sleep", "infinity"]