$slnDir = $PSScriptRoot

Write-Host "Starting CatalogService (Port 5011)..."
Start-Process "dotnet" -ArgumentList "run --project .\CatalogService\CatalogService.csproj" -WorkingDirectory $slnDir

Write-Host "Starting OrderService (Port 5021)..."
Start-Process "dotnet" -ArgumentList "run --project .\OrderService\OrderService.csproj" -WorkingDirectory $slnDir

Write-Host "Starting InventoryService (Port 5031)..."
Start-Process "dotnet" -ArgumentList "run --project .\InventoryService\InventoryService.csproj" -WorkingDirectory $slnDir

Write-Host "Starting UserService (Port 5041)..."
Start-Process "dotnet" -ArgumentList "run --project .\UserService\UserService.csproj" -WorkingDirectory $slnDir

Write-Host "Starting ApiGateway (Port 5001)..."
Start-Process "dotnet" -ArgumentList "run --project .\ApiGateway\ApiGateway.csproj" -WorkingDirectory $slnDir

Write-Host "All services started! You can query the ApiGateway at https://localhost:5001"
Write-Host "Examples:"
Write-Host "  curl -k https://localhost:5001/catalog/1"
Write-Host "  curl -k https://localhost:5001/user/42"
Write-Host "  curl -k https://localhost:5001/inventory/5"

