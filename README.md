This is a small Orders module. The goal was to implement a clean, maintainable backend that reflects real-world practices.

## Tech Stack

- ASP.NET Web API 2 (Framework 4.8)
- Entity Framework 6
- SQL Server

## Endpoints

- `GET /api/orders` — List Orders
- `GET /api/orders?status={from-to}` — List orders From To

## Setup

1. Run `Script.sql` to initialize the database.
2. Update connection string in `Web.config` if needed.
3. Start the Web API project.

## Trade-offs

- Some business rules were enforced in the database to guarantee integrity, at the cost of testability.
- EF6 was used instead of EF Core, sacrificing modern features for compatibility.

## Next Steps

- Add server-side pagination to avoid loading large datasets
- Add global exception filter for consistent error handling.
- Add unit tests for services.
- Migrate to .NET 8
