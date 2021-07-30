# eShoppingSimple

Before the eShoppingSimple solutions for the Order Service and the Shipping Service can be used, please make sure to build for the service chassis solution in Debug configuration, since it writes the nuget packages in the Debug folders which the service solutions require.

The services follows hexagonal architectures, and use the service chassis framework for all cross cutting concerns like Swagger, database connections and event bus connectivity.

# eShopping Service Chassis

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
