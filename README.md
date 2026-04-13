# Evently

Modular monolith built with ASP.NET Core 10 and PostgreSQL.

## Stack

- .NET 10 / ASP.NET Core (Minimal APIs)
- Entity Framework Core 10 + Npgsql (PostgreSQL)
- Docker + Docker Compose
- Scalar (API docs)

## Project Structure

```
src/
  API/
    Evently.Api/              # Entry point — wires up modules, migrations, middleware
  Modules/
    Events/
      Evently.Modules.Events.Api/   # Events domain (endpoints, DbContext, migrations)
```

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

## Running with Docker

Build and start all services:

```bash
docker compose -f compose.yaml -p evently up --build -d
```

This starts:
- **Evently.Api** on `http://localhost:5000`
- **Evently.Database** (PostgreSQL 18) on `localhost:5432`

Migrations are applied automatically on startup in the `Development` environment.

To stop:

```bash
docker compose -f compose.yaml -p evently down
```

## Running locally (without Docker)

Start only the database:

```bash
docker compose -f compose.yaml -p evently up evently.database -d
```

Then run the API:

```bash
dotnet run --project src/API/Evently.Api/Evently.Api.csproj
```

The API will be available at `http://localhost:5167`.

## Database

| Setting  | Value             |
|----------|-------------------|
| Host     | localhost         |
| Port     | 5432              |
| Database | evently           |
| Username | postgres          |
| Password | postgres          |

Connection string (Development):

```
Host=Evently.Database;Port=5432;Database=evently;Username=postgres;Password=postgres
```

## API Documentation

With the application running in Development mode:

- OpenAPI spec: `http://localhost:5000/openapi/v1.json`
- Scalar UI: `http://localhost:5000/scalar/v1`

## Endpoints

| Method | Route         | Description     |
|--------|---------------|-----------------|
| POST   | /events       | Create an event |
| GET    | /events/{id}  | Get event by ID |

## Migrations

Migrations are applied automatically on startup. To add a new migration manually:

```bash
dotnet ef migrations add <MigrationName> \
  --project src/Modules/Events/Evently.Modules.Events.Api \
  --startup-project src/API/Evently.Api
```
