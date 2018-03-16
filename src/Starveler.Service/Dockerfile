FROM microsoft/dotnet

ADD ./bin/Publish app/

ENV ASPNETCORE_URLS="http://+:5001"

WORKDIR app

ENTRYPOINT sleep 20 && dotnet Starveler.Service.dll