# CosmoRedisApi

This project is a learning platform for Redis and Azure Cosmso DB.  It uses a simple layered approach to keep the code as clean as possible.  

### Cosmo

To install Cosmo locally you will need to install from the following link if you want to run it locally [Azure Cosmos Db Emulator](https://learn.microsoft.com/en-us/azure/cosmos-db/local-emulator?tabs=ssl-netstd21#download-the-emulator)

*Please note*: that when running the emulator you will get issues when accessing it through Google Chrome.  It is easier to run it with Edge (there I said it, something Edge is more useful than Chrome)

### Redis

Through out this project I also use Redis, you can sign up for a free in cloud database that you can use from [Redis](https://redis.com/).  

### Docker

To compile the api into a docker container you will need to the following command from terminal window in Rider or Visual Studio

```
docker-compose up
```

To remove the container you will need to run the following command

```
docker-compose down
```
