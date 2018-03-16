FROM microsoft/dotnet

ADD ./bin/Publish app/

ENV ASPNETCORE_URLS="http://+:5000"

WORKDIR app

ENTRYPOINT sleep 20 && dotnet Starveler.Api.dll