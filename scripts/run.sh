docker-compose run --rm wait-for-dependencies
docker-compose up -d --build
docker image prune -f