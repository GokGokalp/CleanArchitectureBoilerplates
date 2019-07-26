# OnionArchitecture

This is a basic implementation of "Onion Architecture" for ASP.NET Core. The goal is to address both the separation of concern and tight coupling issues. Onion architecture provides better testability, maintainability and loosely coupling.

### Boilerplate.API

This project is the layer that handles the presentation (UI,API, etc.) concerns.

### Boilerplate.Domain

This project is our core and backbone project. The core project is the heart and center project of the Onion Architecture like Clean Architecture design. All projects should be depended on this project. Thus core layers always stay pure and if any change applied on the code, this change should be part of an external layer.

This project contains "Models" for domain objects, "Dtos", "Interfaces" for external dependencies.

### Boilerplate.Services

This project contains business logics "Interfaces" and their implementations which are used to communicate between the UI and Infrastructure layer.

### Boilerplate.Infrastructure

This project handles database concerns and other data access operations. The goal is to create an abstraction between "Domain" and "Services" layers.

This project contains "Repositories", "Migrations", "DataContext".