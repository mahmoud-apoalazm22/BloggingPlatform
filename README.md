# Blogging Platform API

A simple blogging platform API built with .NET Core, MS SQL, and Entity Framework using Clean Architecture principles. This API allows users to create accounts, create blog posts, comment on posts, and follow other users. It also includes Swagger documentation for easy testing and exploration of the API endpoints.

## Features

- User registration and authentication
- Create, read, update, and delete blog posts
- Leave comments on blog posts
- Follow and unfollow other users
- Swagger documentation

## Technologies Used

- .NET Core
- Entity Framework Core
- MS SQL Server
- Serilog for logging
- MediatR for CQRS
- FluentValidation for request validation
- Swagger for API documentation

## Clean Architecture

This project follows the principles of Clean Architecture, separating the solution into multiple projects:

- **Application**: Contains business logic and application-specific logic.
- **Domain**: Contains the core entities and domain logic.
- **Infrastructure**: Contains implementations for database access, external services, etc.
- **WebApi**: The entry point of the application, contains the controllers and the presentation layer.

## Getting Started

### Installation

1. Clone the repository

    ```bash
    git clone https://github.com/mahmoud22/BloggingPlatform.git
    cd blogging-platform-api
    ```

2. Set up the database connection string in `appsettings.json` located in the `WebApi` project

    ```json
    {
        "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BloggingPlatform;Trusted_Connection=True;"
    },
    }
    ```

3. Apply the database migrations

    ```bash
    dotnet ef database update --project Infrastructure --startup-project WebApi
    ```

4. Run the application

    ```bash
    dotnet run --project WebApi
    ```

### Usage

#### Swagger Documentation

The API includes Swagger documentation. To explore the API endpoints and test them, navigate to:

