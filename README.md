# Mini Order Management System

A backend application built using ASP.NET Core to demonstrate Clean Architecture,
CQRS, SOLID principles, Entity Framework Core (Code First), Unit of Work,
Repository pattern, Fluent Validation, Swagger API documentation, and Unit Testing.

---

##  Objective

The goal of this project is to build a small but production-style backend system
that clearly demonstrates enterprise backend patterns and best practices.

---

## Architecture Overview

The solution follows **Clean Architecture**, ensuring:

- Clear separation of concerns
- Dependency flow from outer layers to inner layers
- Business logic isolated from infrastructure and frameworks

### Layers:

1. **API Layer** – HTTP endpoints & request handling
2. **Application Layer** – CQRS, business use cases
3. **Domain Layer** – Core business entities and rules
4. **Infrastructure Layer** – EF Core, repositories, database
5. **Test Layer** – Unit tests for application logic

---

## 📂 Solution Structure


---

##  Domain Design

### Entities

- **Customer** (Aggregate Root)
- **CustomerProfile** (One-to-One)
- **Order** (One-to-Many)

### Business Rules

- A customer can have multiple orders
- Each customer has exactly one profile
- Order total amount must be greater than zero
- Customer must exist before placing an order

Business rules are enforced in the **Domain and Application layers**.

---

## CQRS Implementation

The project uses **CQRS (Command Query Responsibility Segregation)**.

### Commands (Write Side)

- `CreateCustomerCommand`
- `CreateOrderCommand`

Handled using **MediatR** and validated using **FluentValidation**.

### Queries (Read Side)

- `GetCustomerByIdQuery`
- `GetOrdersByCustomerIdQuery`

Queries return read-optimized DTOs and use EF Core `Include` for relationships.

---

## Data Access Pattern

### Repository Pattern

- Encapsulates database access
- Prevents EF Core from leaking into application logic

### Unit of Work Pattern

- Coordinates repositories
- Manages transactions
- Ensures atomic saves

Repositories are accessed **only through UnitOfWork**.

---

## Unit Testing

Unit tests are written using:

- **xUnit**
- **Moq**
- **FluentAssertions**

### Covered Tests

- CreateCustomerCommandHandler
- CreateOrderCommandHandler

Tests validate application logic without database dependency.

---

## Validation

**FluentValidation** is used for validating commands.

Examples:

- Customer name is required
- Order total amount must be greater than zero
- Customer must exist before creating an order

---

## API & Swagger

Swagger is enabled in **Development mode**.

### Available Endpoints

- `POST /api/customers`
- `GET /api/customers/{id}`
- `POST /api/orders`
- `GET /api/orders/customer/{customerId}`

Swagger URL:


---

## Database

- SQL Server (LocalDB)
- Entity Framework Core (Code First)
- Migrations used for schema creation
- Relationships configured using Fluent API

---

## How to Run the Project

1. Clone the repository
2. Open the solution in Visual Studio
3. Set **MiniOrderManagement.API** as the startup project
4. Run migrations:


5. Run the application
6. Open Swagger and test the endpoints

---

## 🏁 Conclusion

This project demonstrates real-world backend development practices including
Clean Architecture, CQRS, EF Core, validation, Swagger documentation, and unit testing.
It is structured, scalable, and maintainable.
