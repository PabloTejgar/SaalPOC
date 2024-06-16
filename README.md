# SaalPOC

## Description
SaalPOC is a demo application showcasing a simple restaurant manager system. Users can add their favorite establishments along with details such as names, phone numbers, addresses, and cities.

## Deployment
The application is designed to be deployed on Azure or dockerized for local deployment.

## Features
- **Add New Restaurants**: Easily add new restaurants with details.
- **View Existing Restaurants**: List all added restaurants.
- **City Management**: Manage cities where restaurants are located, now we only have 4 available: León, Rome, Berlin and London.

## Technologies Used
- **ASP.NET Core 8.0**: Framework for building web applications and APIs.
- **Entity Framework Core 8**: ORM for database operations.
- **Swagger**: API documentation.
- **Docker**: Containerization for easy deployment.
- **Azure**: Cloud platform for hosting.

## Design Patterns
- **Generic Repository**: Used for data access, providing a generic way to interact with data entities.
- **MVC (Model-View-Controller)**: Used for structuring the application into three interconnected components to separate concerns.
- **Unit of Work**: Used to manage transactions and simplify the interaction between the business logic layer and the data access layer.

## Setup Instructions
To run the application locally or deploy it, follow these steps:
1. Clone the repository.
2. Configure the database connection string in `appsettings.json`.
3. Build and run the application.

### Running Locally
```bash
dotnet build
dotnet run
