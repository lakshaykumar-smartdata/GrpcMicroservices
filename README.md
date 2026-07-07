# .NET gRPC Microservices & API Gateway

This project demonstrates a minimal microservices architecture using **.NET 9**, featuring a central API Gateway that routes RESTful HTTP requests to isolated backend services via **gRPC**.

## Architecture Overview

The system consists of **5 distinct services**:
- **ApiGateway**: A Minimal API project acting as the single entry point. It serves an interactive UI and exposes REST endpoints. Internally, it translates these REST calls into strongly-typed HTTP/2 gRPC calls.
- **CatalogService**: A backend gRPC service handling item catalog data.
- **OrderService**: A backend gRPC service handling order processing.
- **InventoryService**: A backend gRPC service managing stock levels.
- **UserService**: A backend gRPC service handling user profiles.

All backend services share their `.proto` contracts from the `Shared.Protos` directory, ensuring the Gateway and the services are always in sync.

### Workflow
1. A client (e.g., a browser) makes a standard `GET` or `POST` JSON request to the `ApiGateway`.
2. The Gateway processes the request and calls the appropriate target service using a generated gRPC client over HTTP/2.
3. The target gRPC service processes the RPC and returns a protobuf reply.
4. The Gateway maps the protobuf reply back to a JSON response for the client.

## Getting Started

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- PowerShell (to run the startup script)

### Running the Ecosystem
A PowerShell script is included to launch all 5 projects concurrently without port conflicts.

1. Open PowerShell in the root of the solution.
2. Execute the run script:
   ```powershell
   .\run.ps1
   ```
   *This will start the Gateway on port `5001` and the backend services on ports `5011`, `5021`, `5031`, and `5041`.*

### Interactive Dashboard
Once all services are running, open your web browser and navigate to:
**[https://localhost:5001](https://localhost:5001)**

You will be presented with an interactive **Microservices Dashboard**. 
- It allows you to test all the endpoints directly from your browser.
- It features an animated architecture diagram that visually traces the life of a request as it flows from the Client -> API Gateway -> Target gRPC Service, making it perfect for live demonstrations!

## Endpoints

If you prefer to test via `curl` or Postman, the API Gateway exposes the following REST endpoints:

- `GET https://localhost:5001/catalog/{id}`
- `POST https://localhost:5001/order` (Body: `{ "itemId": 1, "quantity": 2 }`)
- `GET https://localhost:5001/inventory/{id}`
- `GET https://localhost:5001/user/{id}`
