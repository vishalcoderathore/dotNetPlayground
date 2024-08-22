#!/bin/bash

# Stop all running containers
echo "Stopping all running containers..."
docker stop $(docker ps -aq)

# Remove all containers
echo "Removing all containers..."
docker rm -f $(docker ps -aq)

# Remove all images
echo "Removing all images..."
docker rmi -f $(docker images -q)

# Remove all volumes
echo "Removing all volumes..."
docker volume rm $(docker volume ls -q)

# Remove all networks except default ones
echo "Removing all networks..."
docker network rm $(docker network ls | grep "bridge\|host\|none" -v | awk '{print $1}')

# Prune everything to ensure no leftovers
echo "Pruning system to remove unused data..."
docker system prune -af --volumes

echo "Docker system has been cleared."
