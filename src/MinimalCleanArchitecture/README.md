# Minimal.CleanArchitecture

This is a basic implementation of "Clean Architecture" for ASP.NET Core. The goal is to encapsulate the business logic of the application in a clean, loosely coupled and dependency inverted way. MediatR used for in-process messaging.

### Minimal.API

This project is the layer that handles the presentation (UI,API, etc.) concerns.

### Minimal.Core

This project is our core and backbone project. The core project is the heart and center project of the Clean Architecture design. All projects should be depended on the this project.

This project contains "Models" for domain objects, "Dtos", "Events", "Interfaces" for external dependencies, "Use-Cases" for business rules.

### Minimal.Infrastructure

This project handles database concerns and other data access operations.

This project contains "Repositories", "Migrations", "DataContext", and also "Implementations" of the interfaces that we defined in the core project.