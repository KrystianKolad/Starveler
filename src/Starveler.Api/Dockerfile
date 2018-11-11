FROM microsoft/dotnet:2.1-aspnetcore-runtime

ADD ./bin/Publish app/

ENV ASPNETCORE_URLS="http://+:5000"

WORKDIR /app

ENTRYPOINT dotnet Starveler.Api.dll