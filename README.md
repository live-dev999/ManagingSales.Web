# Build info
Azure Build Status (master)/(dev)
| master   |      dev      |
|----------|:-------------:|
| [![Build Status](https://dev.azure.com/o2bionics-products/ManagingSales.Web/_apis/build/status%2FManagingSales.Web?branchName=dev)](https://dev.azure.com/o2bionics-products/ManagingSales.Web/_build/latest?definitionId=61&branchName=master) | [![Build Status](https://dev.azure.com/o2bionics-products/ManagingSales.Web/_apis/build/status%2FManagingSales.Web?branchName=dev)](https://dev.azure.com/o2bionics-products/ManagingSales.Web/_build/latest?definitionId=61&branchName=dev)             |



GitHub Build Status (master)/(dev)

| master   |      dev      |
|----------|:-------------:|
| [![ManagingSales.Web](https://github.com/live-dev999/ManagingSales.Web/actions/workflows/github-ci.yml/badge.svg?branch=master)](https://github.com/live-dev999/ManagingSales.Web/actions/workflows/github-ci.yml) | [![ManagingSales.Web](https://github.com/live-dev999/ManagingSales.Web/actions/workflows/github-ci.yml/badge.svg?branch=dev)](https://github.com/live-dev999/ManagingSales.Web/actions/workflows/github-ci.yml)


## **Preinstalled software**
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) or [Microsoft VS Code](https://visualstudio.microsoft.com/downloads/)
- [Microsoft SQL Server or Docker image with (minimal version version 2019 and up)](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) 
- [.Net Core 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
  
## Information about task
[TASK-FOR-DEVELOPER.md](TASK-FOR-DEVELOPER.md)

## **Getting Started**
### Steps: 
1. Install [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) database or deploy database using docker
2. Set environment in appSettings.json and appSettings.Development.json
3. Migrate EF CORE or deploy a database backup
4. Build and run project (use dotnet commands or use IDEs([Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) or [Microsoft VS Code](https://visualstudio.microsoft.com/downloads/))



## **Deploy databases**
Possible Database deployment scenarios:
+ use Azure SQL databse in Microsoft Azure Cloud
+ use docker or docker-compose
+ deploy local database


### Use Azure SQL databse in Microsoft Azure Cloud (main method)
To work with the database in Microsoft Azure, you need to remember to set a firewall rule for your IP address. [Firewall configuration is done through the Microsoft Azure panel.](https://learn.microsoft.com/en-us/azure/azure-sql/database/firewall-configure?view=azuresql)

### Use Docker or Docker compose(alternative method)
Run database use docker:

```
sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourStrong@Passw0rd" \
   -p 1433:1433 --name sql1 --hostname sql1 \
   -d \
   mcr.microsoft.com/mssql/server:2019-latest
```


Run database use docker-compose:
Create docker-compose.yaml file in root folder with code:
```version: '3.7'

services:
  sql.data:
    image: mcr.microsoft.com/mssql/server:2019-latest
    container_name: sqldatacontainer
```
Create docker-compose.override.yaml in root folder with code:
```
version: '3.7'

services:
  sql.data:
    image: mcr.microsoft.com/mssql/server:2019-latest
    container_name: sqldatacontainer
```
So, Now we can run docker-compose command for create local docker image

```
docker-compose -f docker-compose.yml -f docker-compose.override.yml up
```

if you use docker-compose for arm

```
docker-compose -f docker-compose.arm.yml -f docker-compose.override.yml up
```

### **Deploy local database in your machine (alternative method)**
Go to link [for download Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads). IInstall Microsoft SQL Server using the installer or any other method available.


## Build and run applications
Before launching, be sure to set the variables in the appsettings.json configuration files. It is important to specify the correct database connection string
```
 "ConnectionStrings": {
    "ManagingSalesContextConnection": "Server=tcp:<server>,<port>;Initial Catalog=<databasename>;Persist Security Info=False;User ID=<user>;Password=<password>;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  },
```
Can use commands use terminal or use IDEs(Microsoft Visual Studio 2022 or VS Code):
```
dotnet build [options]
dotnet run [options]
```

## **IMPORTANT NOTES!**
***If you are using an empty database then you need to migrate using the command***
```
dotnet ef database update --project .\ManagingSales.Data\ManagingSales.Data.csproj --startup-project .\ManagingSales.API\ManagingSales.API.csproj -c ManagingSalesContext
```
The source code contains sql scripts, so these scripts must be executed

## **Known Issues**
Issue with database connection when working with local database, docker or docker image deployed with database
***how to solve it. In the connection string, turn off the flag with the name***