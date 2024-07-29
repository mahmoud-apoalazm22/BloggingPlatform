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
<div>
    ![logging](https://github.com/user-attachments/assets/9467a6f9-b77f-4918-b18d-6c61f72d5de0)![2](https://github.com/user-attachments/assets/222f4bd5-05c9-4343-a252-cec3b24d9332)
    <img src="https://github.com/user-attachments/assets/222f4bd5-05c9-4343-a252-cec3b24d9332">
    <img src="https://github.com/user-attachments/assets/9467a6f9-b77f-4918-b18d-6c61f72d5de0">

</div>


#### User Registration and Authentication

- **Register a new user**

    ```http
    POST /api/Users/register
    ```

    Request body:
    ```json
    {
        "username": "johndoe",
        "email": "johndoe@example.com",
        "password": "P@ssw0rd"
    }
    ```

- **Login**

    ```http
    POST /api/Users/login
    ```

    Request body:
    ```json
    {
        "email": "johndoe@example.com",
        "password": "P@ssw0rd"
    }
    ```

#### Blog Posts

- **Create a blog post**

    ```http
    POST /api/BlogPosts
    ```

    Request body:
    ```json
    {
        "title": "My First Blog Post",
        "content": "This is the content of my first blog post."
    }
    ```

- **Get all blog posts**

    ```http
    GET /api/BlogPosts
    ```

- **Get a blog post by ID**

    ```http
    GET /api/BlogPosts/{id}
    ```

- **Update a blog post**

    ```http
    PUT /api/BlogPosts/{id}
    ```

    Request body:
    ```json
    {
        "title": "Updated Title",
        "content": "Updated content."
    }
    ```

- **Delete a blog post**

    ```http
    DELETE /api/BlogPosts/{id}
    ```

#### Comments

- **Add a comment to a blog post**

    ```http
    POST /api/BlogPosts/{blogPostId}/comments
    ```

    Request body:
    ```json
    {
        "commenterName": "Jane Doe",
        "commenterEmail": "jane.doe@example.com",
        "text": "This is a comment."
    }
    ```

#### Follow/Unfollow Users

- **Follow a user**

    ```http
    POST /api/Users/{userIdToFollow}/follow
    ```

- **Unfollow a user**

    ```http
    DELETE /api/Users/{userIdToUnfollow}/unfollow
    ```

## Logging

Logging is configured using Serilog. Logs are written to the console and to files in the `Logs` directory with a rolling interval of one day.

## Project Structure


