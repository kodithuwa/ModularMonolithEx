# Modular Monolith Example

A small .NET 9 pilot exploring modular monolith structure and in-process request handling with [MediatR](https://github.com/jbogard/MediatR). The solution currently contains a Products web application, an Orders console prototype, and shared registration abstractions.

## Solution structure

```text
ModularMonolithEx.sln
+-- Products/   ASP.NET Core web app and Products module
+-- Orders/     Orders domain and MediatR handlers; console prototype
`-- Common/     Repository/service marker interfaces and DI registration helper
```

### Products

`Products` is the only ASP.NET Core host. Its application code is arranged around a product model, repository interface/implementation, MediatR query, and query handler:

```text
Products/
+-- Controllers/                 WeatherForecast sample controller
+-- Application/
|   +-- Handlers/                 GetProductByIdHandler
|   +-- Models/                   Product
|   +-- Queries/                  GetProductByIdQuery
|   `-- Repositories/             IProductRepository, in-memory ProductRepository
+-- Program.cs                    Web host and dependency registration
`-- ProductsModule.cs             Module MediatR registration helper
```

The product repository currently returns two hard-coded products. `Program.cs` registers it and MediatR directly. The project also contains a `ProductsModule.Register` helper, but the web host does not currently call that helper.

### Orders

`Orders` contains order domain types, a create-order command/handler, query handlers, and DTOs. Its `Program` is a console entry point that builds a dependency injection container and sends `GetOrderWithProductDetailsQuery` through MediatR. That handler requests a product through the same mediator and combines it with a mocked order ID and quantity.

The module defines `IOrderRepository` and a `CreateOrderHandler`, but there is no concrete order repository in the solution yet. `OrdersModule.Register` is available for registering the module's MediatR handlers; the current console entry point performs handler registration itself and manually registers repository implementations discovered from assemblies.

### Common

`Common` provides `IRepository` and `IService` marker interfaces and `AddRepositoriesFromAssembly`, a reflection-based helper that looks for implementations and registers matching interfaces in dependency injection. Product's current repository does not implement the shared `IRepository` marker, so it is registered explicitly by the Products web host.

## Request flow

```text
Orders console
  `-- IMediator.Send(GetOrderWithProductDetailsQuery)
       `-- GetOrderWithProductDetailsHandler
            `-- IMediator.Send(GetProductByIdQuery)
                 `-- GetProductByIdHandler
                      `-- IProductRepository (in-memory)
```

MediatR provides in-process dispatch between requests and handlers; this is not a distributed service call. The sample currently demonstrates a cross-module call from Orders to Products through the mediator, while both modules are compiled into the same solution.

## Run

Prerequisite: the .NET 9 SDK.

Run the Products web host:

```bash
dotnet run --project Products/Products.csproj
```

The host maps controllers. The included controller is the ASP.NET Core WeatherForecast sample; a product HTTP endpoint has not been added yet. Launch URLs are configured in `Products/Properties/launchSettings.json`.

Run the Orders console prototype:

```bash
dotnet run --project Orders/Orders.csproj
```

The console sends a sample request for order ID `1` and product ID `1`. The result is currently assigned but not printed.

Build the full solution:

```bash
dotnet build ModularMonolithEx.sln
```

## Current scope

- .NET 9 projects with nullable reference types and implicit usings enabled.
- MediatR-based commands and queries registered from each module's assembly.
- In-memory product data; no database, persistence layer, or concrete order repository is configured.
- Products is an HTTP host; Orders is currently a console executable rather than an HTTP module.
- No automated test projects are included in the solution yet.
