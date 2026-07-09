# .NET YARP Reverse Proxy Microservices

This project demonstrates a minimal microservices architecture using **.NET 9**, featuring a central API Gateway that utilizes Microsoft's **YARP (Yet Another Reverse Proxy)** to route RESTful HTTP requests to isolated backend services.

## Architecture Overview

The system consists of **5 distinct services**:
- **ApiGateway**: The entry point powered by YARP. It serves an interactive UI and acts as a pure reverse proxy. It transparently routes incoming REST calls to the appropriate backend service using configuration-based routing (defined in `appsettings.json`), without requiring custom C# forwarding logic.
- **CatalogService**: A backend REST service handling item catalog data.
- **OrderService**: A backend REST service handling order processing.
- **InventoryService**: A backend REST service managing stock levels.
- **UserService**: A backend REST service handling user profiles.

### Workflow
1. A client (e.g., a browser) makes a standard `GET` or `POST` JSON request to the `ApiGateway`.
2. YARP intercepts the request, matches it against its routing table, and proxies it to the designated backend cluster.
3. The target REST service processes the request and returns standard JSON.
4. YARP forwards the JSON response back to the client.

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
- It features an animated architecture diagram that visually traces the life of a request as it flows from the Client -> API Gateway -> Target REST Service.

## Endpoints

If you prefer to test via `curl` or Postman, the API Gateway exposes the following REST endpoints that proxy to the backends:

- `GET https://localhost:5001/catalog/{id}`
- `POST https://localhost:5001/order` (Body: `{ "itemId": 1, "quantity": 2 }`)
- `GET https://localhost:5001/inventory/{id}`
- `GET https://localhost:5001/user/{id}`

