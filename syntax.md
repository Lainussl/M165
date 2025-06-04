- sudo apt install -y dotnet-sdk-8.0
- dotnet new webapi -n TestMongodb
- cd TestMongodb
- dotnet add package MongoDB.Driver
( MongoDB.Driver / MongoDB.Bson / MongoDB.Driver.Core )



mkdir min-api-with-mongo
cd min-api-with-mongo
dotnet new web --name WebApi --framework net8.0
code .
