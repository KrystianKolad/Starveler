FROM microsoft/dotnet

ADD ./bin/Publish app/

ENV ASPNETCORE_URLS="http://+:5001"

WORKDIR app

ENTRYPOINT dotnet Starveler.Service.dll