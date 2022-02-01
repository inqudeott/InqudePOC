# InqudePOC
#about the project 
This repository is for the back end  of the inqudeott platform developed using dotnet core version 5. its using entity framework for data handling and mysql data base is used. 

#How to run the project 
change the connection string “MySQLConnectionString” in appsettings.json
run the docker for initiating the db migration

please make sure  dotnet core verison 5 should be installed as pre requisite

run the following commands in the root folder

dotnet restore

dotnet run

then launch the swagger using the http://localhost:5001/swagger
