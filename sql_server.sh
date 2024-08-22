#!/bin/bash

# Set environment variables
ACCEPT_EULA=Y
SA_PASSWORD="YourStrong!Passw0rd"
MSSQL_PID="Developer"
CONTAINER_NAME="sql_server_2022"
IMAGE="mcr.microsoft.com/mssql/server:2022-latest"
PORT=1433

# Pull the SQL Server image
docker pull $IMAGE

# Run the container
docker run -e "ACCEPT_EULA=$ACCEPT_EULA" -e "MSSQL_SA_PASSWORD=$SA_PASSWORD" -e "MSSQL_PID=$MSSQL_PID" \
-p $PORT:1433 --name $CONTAINER_NAME -d $IMAGE

# Output the container status
docker ps -a | grep $CONTAINER_NAME
