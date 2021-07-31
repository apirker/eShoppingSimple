# eShoppingSimple

This repository contains three different solutions:

* eShoppingSimple.Orders.sln
* eShoppingSimple.Shippings.sln
* eShoppingSimple.ServiceChassis.sln

The solution eShoppingSimple.Orders.sln contains a very simple implementation of an order service to demonstrate the usage of the service chassis. Similarly, the solution eShoppingSimple.Shippings.sln contains a very simple implementation of a shipping service which also uses the service chassis. Both services use HTTP for transport, and they rely on the service chassis in form of nuget packages, defined by the file nuget.config. Before the service solutions for the order service and the shipping service can be used, please make sure to build the service chassis solution in Debug configuration, since it writes the nuget packages in the Debug folders which the service solutions require as specified within the nuget.config file.

The services implement both hexagonal architectures, and use the service chassis framework for all cross cutting concerns like Swagger, database connections and event bus connectivity. The assemblies of a service solution include:

* Domain assembly: Only business logic specific to the service
* Storage assembly: Defines the data model of the service, the EF Core database context, and mappers to translate between domain and data model
* WebAPI assembly: HTTP controllers to access the service
* Service Access assembly: Contains service client implementations to easily access the API controllers without knowing anything about the transport protocol, API endpoints, etc.
* DevTools assembly: Unit test assembly to demonstrate the use of the service access assembly to access the corresponding service.

# eShopping Service Chassis

The service chassis solution supports only two cross cutting concerns: 

* Database: EF Core is being used, with two switchable providers (InMemory, SqlServer)
* Messaging: Contains a mock implementation, and support for Rabbit MQ

Further, the service chassis solution contains three assemblies which wrap access to all cross cutting concerns for the respective service assemblies:

* ServiceChassis.Domain: Contains base command and base query to be implemented by the domain assembly of a service - to be referenced by domain assemblies
* ServiceChassis.Storage: Contains the start up classes for starting EF Core and configuring it - to be referenced by storage assemblies
* ServiceChassis.WebApi: Contains the service startup and support for swagger etc. - to be referenced by WebAPI assemblies

In order to use the service chassis, make sure your appsettings.json file contains the following settings:

"EventSettings": {
    "ServiceName" : "OrderService",
     "MaxResponseWaitingTime" : "20000",
    "Provider" :  "Fake"
  },
"StorageSettings": {
    "DbName": "OrderDb",
    "DbType": "InMemory",
    "ConnectionString": "<your connection string>"
  }
  
For DbType the values "InMemory" or "SqlServer" are supported. For the Provider of the event settings either "Fake" or "RabbitMq" are supported. When RabbitMq is being used, other options have to be set according the RabbitMq options/settings class in the service chassis framework.
