docker run -d -p 1433:1433 -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Starv123!.' --name Starveler-dev-db microsoft/mssql-server-linux
(cd ../src/Starveler.Api; dotnet ef database update)