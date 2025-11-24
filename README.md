# Orders & Metrics Module

The goal of this module is to implement a clean, maintainable backend that reflects real-world practices while balancing legacy constraints with modern patterns.

## Tech Stack

- ASP.NET Web API 2 (Framework 4.8)
- Entity Framework 6
- SQL Server
- CSV-based repository for order ingestion
- NUnit + Moq for unit testing
- Custom response wrapper (`AppResult<T>`) for consistent API responses

## Endpoints

### Orders

- `POST /api/orders/search` — Search orders by criteria (paged request)
- `GET /api/orders` — List all orders (paged)
- `POST /api/orders` — Create a new order

### Metrics

- `GET /api/metrics?topNSku={n}` — Returns daily totals and top SKUs

## Setup

1. Run `Script.sql` to initialize the database.
2. Place your `orders.csv` file in the configured path.
3. Update connection string in `Web.config` if needed.
4. Start the Web API project.

## Trade-offs

- **Infrastructure vs Services Testing**

  - Infrastructure (CSV repository, EF6) is tested via integration tests.
  - Services (metrics, business logic) are unit tested with NUnit + Moq.
  - Trade-off: prioritizing service tests for correctness, while keeping infra tests lightweight.

- **CSV Repository Design**

  - Defensive parsing: invalid rows are skipped instead of crashing.
  - Trade-off: skipping improves stability but reduces visibility into bad data. Logging could be added.

- **DTO Mapping**
  - Manual mapper used for clarity and separation of concerns.
  - Trade-off: more boilerplate, but easier to maintain when DTOs evolve, we can implement Automapper.
- **Legacy Framework**
  - ASP.NET Web API 2 and EF6 chosen for compatibility with .NET Framework 4.8.
  - Trade-off: missing modern features (EF Core LINQ improvements).

## Migration Path to .NET 8

1. **Upgrade Project**

   - Move from .NET Framework 4.8 → .NET 8 (ASP.NET Core Web API).
   - Replace `Web.config` with `appsettings.json`.

2. **Entity Framework**

   - Replace EF6 with EF Core 8.
   - Benefits: better LINQ support, improved performance.

3. **Dependency Injection**

   - Use built-in DI container in ASP.NET Core.
   - Register services and repositories in `Program.cs`.

4. **Middleware**

   - Replace global exception filters with ASP.NET Core middleware.
   - Add logging and structured error responses.

5. **Testing**
   - NUnit + Moq remain valid.
   - Add integration tests with `WebApplicationFactory`.

## Next Steps

- Add structured logging for skipped CSV rows.
- Complete migration to .NET 8 for modern features and long-term support.
