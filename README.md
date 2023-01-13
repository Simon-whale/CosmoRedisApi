# CosmoRedisApi

This project is a learning platform for Redis and Azure Cosmso DB.  It uses a simple layered approach to keep the code as clean as possible.  

### Cosmo

To install Cosmo locally you will need to install from the following link if you want to run it locally [Azure Cosmos Db Emulator](https://learn.microsoft.com/en-us/azure/cosmos-db/local-emulator?tabs=ssl-netstd21#download-the-emulator)

**Please note**: that when running the emulator you will get issues when accessing it through Google Chrome.  It is easier to run it with Edge (there I said it, something Edge is more useful than Chrome)

### Redis

Through out this project I also use Redis, you can sign up for a free in cloud database that you can use from [Redis](https://redis.com/).  

### Docker

This section is a few command that will allow you to install the api into docker container.  Also remember that the API in the container will not show swagger as it is the production environment. 

 To enable it you will need to add the following to the **Dockerfile**, above the EXPOSE port line, this would then enable swagger by setting the environment to Development

```
ENV ASPNETCORE_ENVIRONMENT=Development 
```

To compile and install the API in an container, you need to run the following command
```
docker-compose up
```

To remove the container you will need to run the following command

```
docker-compose down
```
