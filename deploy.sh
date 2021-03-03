#!/bin/bash
dotnet publish -c Release
cp Dockerfile ./bin/Release/netcoreapp3.1/publish/Dockerfile
docker build -t netreader ./bin/Release/netcoreapp3.1/publish
heroku container:push web -a netreader
heroku container:release web -a netreader
