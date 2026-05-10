# Enhanced TODO API

A production-quality RESTful API built with ASP.NET Core Web API.
Implements Models, DTOs, Services, validation,  error handling,
and proper HTTP status codes.


## Tech Stack

- C# / ASP.NET Core Web API
- .NET 8
- Swagger / OpenAPI
- In-Memory Storage


## Project Structure

TODOAPI/
├── Controllers/
│   └── TodosController.cs     # Handles HTTP requests
├── DTOs/
│   ├── CreateTodoDto.cs       # Input DTO for creating todos
│   ├── UpdateTodoDto.cs       # Input DTO for updating todos
│   └── TodoResponseDto.cs     # Output DTO for responses
├── Models/
│   ├── ToDoItem.cs            # Core data model
├── Services/
│   ├── ITodoService.cs        # Service interface
│   └── TodoService.cs         # Business logic
├── Responses/
│    ├── ErrorResponse.cs       # Standardized error format
└── Program.cs                 # App configuration


## Getting Started

### Prerequisites
- .NET 8 SDK
- Visual Studio 2022 or VS Code

### Run the Project

1. Clone the repository
   git clone https://github.com/peculiarprecious/TODOAPI.git

2. Navigate to project folder
   cd TODOAPI

3. Run the project
   Build http

4. Open Swagger UI
   https://localhost:7138/swagger


## API Endpoints

Base URL: https://localhost:7138/api/Todos

| Method | Endpoint | Description | Status Codes |
|--------|----------|-------------|--------------|
| GET | /api/Todos | Get all todos | 200 |
| GET | /api/Todos/{id} | Get todo by ID | 200, 404 |
| POST | /api/Todos | Create new todo | 201, 400 |
| PUT | /api/Todos/{id} | Update todo | 200, 400, 404 |
| DELETE | /api/Todos/{id} | Delete todo | 204, 404 |


## Request & Response Examples

### GET /api/Todos
Response 200 OK
[
  {
    "id": 1,
    "title": "Buy groceries",
    "description": "Milk and eggs",
    "isCompleted": false,
    "createdAt": "2026-05-08T10:30:00",
    "dueDate": "2026-12-01T00:00:00",
    "priority": "High"
  }
]


### POST /api/Todos
Request Body
{
  "title": "Buy groceries",
  "description": "Milk and eggs",
  "dueDate": "2026-12-01T00:00:00",
  "priority": "High"
}

Response 201 Created
{
  "id": 1,
  "title": "Buy groceries",
  "description": "Milk and eggs",
  "isCompleted": false,
  "createdAt": "2026-05-08T10:30:00",
  "dueDate": "2026-12-01T00:00:00",
  "priority": "High"
}

Response 400 Bad Request
{
  "statusCode": 400,
  "message": "Validation failed",
  "errors": {
    "Title": ["Title is required"]
  },
  "timestamp": "2026-05-08T10:30:00"
}


### PUT /api/Todos/{id}
Request Body
{
  "title": "Updated title",
  "description": "Updated description",
  "isCompleted": true,
  "dueDate": "2026-12-01T00:00:00",
  "priority": "Medium"
}

Response 200 OK — returns updated todo
Response 404 Not Found — id does not exist
Response 400 Bad Request — validation failed


### DELETE /api/Todos/{id}
Response 204 No Content — successfully deleted
Response 404 Not Found — id does not exist

## Validation Rules

| Field | Rules |
|-------|-------|
| Title | Required, 3-100 characters, no whitespace only |
| Description | Optional, max 500 characters |
| Priority | Must be Low, Medium, or High |
| DueDate | Optional, cannot be in the past |


## Error Response Format

All errors return this standardized format:
{
  "statusCode": 400,
  "message": "Validation failed",
  "errors": {
    "FieldName": ["Error message"]
  },
  "timestamp": "2026-05-08T10:30:00"
}


## Status Codes

| Code | Meaning |
|------|---------|
| 200 OK | Request successful |
| 201 Created | Resource created successfully |
| 204 No Content | Deleted successfully |
| 400 Bad Request | Validation failed |
| 404 Not Found | Resource not found |
| 500 Internal Server Error | Server error |


## Author

Precious Nwajei
GitHub: https://github.com/peculiarprecious