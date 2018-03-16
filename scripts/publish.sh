./build.sh
dotnet publish ../src/Starveler.Api -c Release -o ./bin/Publish
dotnet publish ../src/Starveler.Service -c Release -o ./bin/Publish