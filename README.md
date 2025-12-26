# FinWise API

<div align="center">

![FinWise Logo](https://via.placeholder.com/150x150/4A90E2/FFFFFF?text=FinWise)

**Modern Personal Finance Management Platform**

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?logo=c-sharp&logoColor=white)](https://docs.microsoft.com/dotnet/csharp/)
[![Build Status](https://img.shields.io/github/actions/workflow/status/yourusername/finwise-api/ci-cd.yml?branch=main)](https://github.com/yourusername/finwise-api/actions)
[![Code Coverage](https://img.shields.io/codecov/c/github/yourusername/finwise-api?logo=codecov)](https://codecov.io/gh/yourusername/finwise-api)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![API Version](https://img.shields.io/badge/API-v1.0.0-blue)](https://finwise-api.azurewebsites.net/swagger)

[Features](#-features) •
[Architecture](#-architecture) •
[Quick Start](#-quick-start) •
[API Documentation](#-api-documentation) •
[Contributing](#-contributing)

</div>

---

## 🎯 Overview

**FinWise** is a production-ready RESTful API for personal finance management, built with .NET 10 and following industry best practices. It demonstrates enterprise-grade architecture patterns including Clean Architecture, Domain-Driven Design (DDD), and CQRS, with comprehensive testing, observability, and security implementations.

### Why FinWise?

- 🏗️ **Clean Architecture** - Separation of concerns with clear layer boundaries
- 🎯 **DDD & CQRS** - Rich domain model with command/query separation
- 🔒 **Security First** - JWT authentication, HTTPS, OWASP Top 10 protection
- 🧪 **80%+ Test Coverage** - Unit, integration, and E2E tests
- 📊 **Full Observability** - Structured logging, metrics, distributed tracing
- 🐳 **Containerized** - Docker support with multi-stage builds
- 🚀 **Production Ready** - CI/CD pipeline, health checks, auto-scaling
- 📖 **Well Documented** - Swagger/OpenAPI, inline documentation

---

## ✨ Features

### Core Functionality

- **User Management**
  - User registration with email validation
  - Secure authentication with JWT tokens
  - Password encryption using PBKDF2

- **Transaction Management**
  - Create income and expense transactions
  - Update and soft-delete transactions
  - Filter by type, category, date range
  - Pagination support

- **Category System**
  - Default system categories (Food, Transport, Health, etc.)
  - Custom user-defined categories
  - Category-based transaction grouping

- **Dashboard & Analytics**
  - Current balance calculation
  - Projected balance (including future transactions)
  - Balance analysis by category
  - Transaction history with filters

### Technical Features

- RESTful API following best practices
- JWT-based authentication
- Entity Framework Core with SQL Server
- FluentValidation for input validation
- Serilog for structured logging
- Application Insights for monitoring
- Docker & Docker Compose support
- Health checks and readiness probes
- CORS configuration
- Rate limiting
- Swagger/OpenAPI documentation

---

## 🏛️ Architecture

FinWise follows **Clean Architecture** principles with clear separation of concerns:

```
┌─────────────────────────────────────────────────────────────┐
│                    Presentation Layer                        │
│              (API Controllers, Middleware)                   │
├─────────────────────────────────────────────────────────────┤
│                    Application Layer                         │
│        (Use Cases, Commands, Queries, Handlers)             │
├─────────────────────────────────────────────────────────────┤
│                      Domain Layer                            │
│    (Entities, Value Objects, Domain Services, Events)       │
├─────────────────────────────────────────────────────────────┤
│                  Infrastructure Layer                        │
│     (EF Core, Repositories, External Services, Auth)        │
└─────────────────────────────────────────────────────────────┘
```

### Project Structure

```
FinWise/
├── src/
│   ├── FinWise.API/                  # Presentation Layer
│   │   ├── Controllers/              # REST endpoints
│   │   ├── Middleware/               # Cross-cutting concerns
│   │   ├── Filters/                  # Action filters
│   │   └── Program.cs                # Application entry point
│   │
│   ├── FinWise.Application/          # Application Layer
│   │   ├── UseCases/                 # Commands & Queries
│   │   │   ├── Auth/                 # Authentication use cases
│   │   │   ├── Transactions/         # Transaction use cases
│   │   │   ├── Categories/           # Category use cases
│   │   │   └── Dashboard/            # Dashboard use cases
│   │   ├── DTOs/                     # Data Transfer Objects
│   │   ├── Mappings/                 # Object mappings
│   │   └── Interfaces/               # Service abstractions
│   │
│   ├── FinWise.Domain/               # Domain Layer
│   │   ├── Entities/                 # Domain entities
│   │   ├── ValueObjects/             # Value objects
│   │   ├── Enums/                    # Domain enumerations
│   │   ├── Events/                   # Domain events
│   │   ├── Services/                 # Domain services
│   │   └── Interfaces/               # Repository interfaces
│   │
│   └── FinWise.Infrastructure/       # Infrastructure Layer
│       ├── Persistence/              # Data access
│       │   ├── Context/              # EF Core DbContext
│       │   ├── Configurations/       # Entity configurations
│       │   ├── Repositories/         # Repository implementations
│       │   └── Migrations/           # Database migrations
│       └── Services/                 # External services
│           ├── Auth/                 # JWT & Password hashing
│           └── Email/                # Email service
│
├── tests/
│   ├── FinWise.Domain.Tests/         # Domain unit tests
│   ├── FinWise.Application.Tests/    # Application unit tests
│   ├── FinWise.Infrastructure.Tests/ # Infrastructure integration tests
│   └── FinWise.API.Tests/            # API integration tests
│
├── docker-compose.yml                # Docker orchestration
├── Dockerfile                        # Multi-stage Docker build
└── README.md                         # This file
```

### Technology Stack

| Layer | Technologies |
|-------|-------------|
| **API** | ASP.NET Core 10, Swagger/OpenAPI |
| **Application** | CQRS, FluentValidation, AutoMapper |
| **Domain** | C# 12, SOLID principles, DDD patterns |
| **Infrastructure** | Entity Framework Core, SQL Server, JWT |
| **Testing** | xUnit, FluentAssertions, Moq, TestContainers |
| **Observability** | Serilog, Application Insights, OpenTelemetry |
| **DevOps** | Docker, GitHub Actions, Azure/AWS |

---

## 🚀 Quick Start

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) (optional, for containerized setup)
- [SQL Server 2022](https://www.microsoft.com/sql-server) or Docker

### Option 1: Run with Docker (Recommended)

```bash
# Clone the repository
git clone https://github.com/yourusername/finwise-api.git
cd finwise-api

# Start all services (API + SQL Server)
docker-compose up -d

# Wait for services to be healthy (check with)
docker-compose ps

# Access the API
open http://localhost:5000/swagger
```

### Option 2: Run Locally

```bash
# Clone the repository
git clone https://github.com/yourusername/finwise-api.git
cd finwise-api

# Restore dependencies
dotnet restore

# Update connection string in appsettings.Development.json
# Then apply database migrations
cd src/FinWise.API
dotnet ef database update

# Run the application
dotnet run

# Access the API
open https://localhost:5001/swagger
```

### Option 3: Run with Docker Compose (Development)

```bash
# Build and run
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

# View logs
docker-compose logs -f api

# Stop services
docker-compose down
```

---

## 📡 API Documentation

### Swagger UI

Interactive API documentation is available at:
- **Local**: http://localhost:5000/swagger
- **Production**: https://finwise-api.azurewebsites.net/swagger

### Authentication

The API uses JWT Bearer authentication. To authenticate:

1. **Register a new user**:
```bash
POST /api/auth/register
{
  "email": "user@example.com",
  "name": "John Doe",
  "password": "SecureP@ssw0rd"
}
```

2. **Login to get JWT token**:
```bash
POST /api/auth/login
{
  "email": "user@example.com",
  "password": "SecureP@ssw0rd"
}
```

3. **Use token in subsequent requests**:
```bash
Authorization: Bearer <your-jwt-token>
```

### Key Endpoints

| Endpoint | Method | Description | Auth Required |
|----------|--------|-------------|---------------|
| `/api/auth/register` | POST | Register new user | ❌ |
| `/api/auth/login` | POST | Login and get JWT token | ❌ |
| `/api/transactions` | GET | List user transactions | ✅ |
| `/api/transactions` | POST | Create new transaction | ✅ |
| `/api/transactions/{id}` | GET | Get transaction by ID | ✅ |
| `/api/transactions/{id}` | PUT | Update transaction | ✅ |
| `/api/transactions/{id}` | DELETE | Delete transaction | ✅ |
| `/api/categories` | GET | List categories | ✅ |
| `/api/categories` | POST | Create custom category | ✅ |
| `/api/dashboard/balance` | GET | Get current balance | ✅ |
| `/health` | GET | Health check endpoint | ❌ |

### Example Requests

**Create a Transaction**:
```bash
curl -X POST "https://localhost:5001/api/transactions" \
  -H "Authorization: Bearer YOUR_TOKEN" \
  -H "Content-Type: application/json" \
  -d '{
    "amount": 150.00,
    "description": "Grocery shopping",
    "type": "Expense",
    "date": "2025-12-26T14:30:00Z",
    "categoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "notes": "Weekly groceries at supermarket"
  }'
```

**Get Balance**:
```bash
curl -X GET "https://localhost:5001/api/dashboard/balance?includeFuture=false" \
  -H "Authorization: Bearer YOUR_TOKEN"
```

---

## 🧪 Testing

### Run All Tests

```bash
# Run all tests with coverage
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover

# Generate HTML coverage report
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator -reports:**/coverage.opencover.xml -targetdir:./coverage-report -reporttypes:Html

# Open coverage report
open coverage-report/index.html
```

### Test Categories

- **Unit Tests**: Fast, isolated tests for domain logic and application handlers
- **Integration Tests**: Tests with real database (in-memory or TestContainers)
- **API Tests**: End-to-end tests using WebApplicationFactory

### Test Coverage

Current coverage: **82%** ✅

| Layer | Coverage |
|-------|----------|
| Domain | 95% |
| Application | 88% |
| Infrastructure | 75% |
| API | 70% |

---

## 🔧 Configuration

### Environment Variables

Create a `.env` file in the root directory:

```env
# Database
ConnectionStrings__DefaultConnection=Server=localhost;Database=FinWiseDB;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True

# JWT
Jwt__SecretKey=YourSuperSecretKeyThatIsAtLeast32CharactersLong
Jwt__Issuer=FinWise
Jwt__Audience=FinWiseClients
Jwt__ExpirationMinutes=1440

# Application Insights (optional)
ApplicationInsights__ConnectionString=InstrumentationKey=...

# Environment
ASPNETCORE_ENVIRONMENT=Development
```

### appsettings.json

Key configuration sections:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=FinWiseDB;..."
  },
  "Jwt": {
    "SecretKey": "your-secret-key",
    "Issuer": "FinWise",
    "Audience": "FinWiseClients",
    "ExpirationMinutes": 1440
  },
  "Serilog": {
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning"
      }
    }
  }
}
```

---

## 🔒 Security

FinWise implements multiple layers of security:

- ✅ **HTTPS/TLS** - All communications encrypted
- ✅ **JWT Authentication** - Stateless token-based auth
- ✅ **Password Hashing** - PBKDF2 with salt
- ✅ **SQL Injection Protection** - Parameterized queries via EF Core
- ✅ **XSS Protection** - Automatic HTML encoding
- ✅ **CSRF Protection** - Via JWT (no cookies)
- ✅ **Rate Limiting** - Prevents brute force attacks
- ✅ **Security Headers** - HSTS, X-Frame-Options, CSP, etc.
- ✅ **CORS** - Configured for specific origins
- ✅ **Input Validation** - FluentValidation on all inputs
- ✅ **LGPD Compliance** - Data privacy and user rights

### Security Headers

```
Strict-Transport-Security: max-age=31536000; includeSubDomains
X-Content-Type-Options: nosniff
X-Frame-Options: DENY
X-XSS-Protection: 1; mode=block
Content-Security-Policy: default-src 'self'
```

---

## 📊 Monitoring & Observability

### Health Checks

- **Basic Health**: `/health` - Returns 200 if API is running
- **Detailed Health**: `/health/detailed` - Includes database and dependencies

### Logging

Structured logging with Serilog:
- Console sink (development)
- File sink with JSON formatting
- Seq for log aggregation (optional)
- Application Insights (production)

### Metrics

Custom metrics tracked:
- Request rate and latency (p50, p95, p99)
- Error rate
- Transaction creation rate
- Active users
- Database connection pool

### Distributed Tracing

OpenTelemetry integration with:
- Request tracing
- Database query tracing
- External API call tracing
- Export to Jaeger or Application Insights

---

## 🚢 Deployment

### Docker Deployment

```bash
# Build production image
docker build -t finwise-api:latest .

# Run container
docker run -d \
  -p 8080:8080 \
  -e ConnectionStrings__DefaultConnection="..." \
  -e Jwt__SecretKey="..." \
  --name finwise-api \
  finwise-api:latest
```

### Azure App Service

```bash
# Deploy to Azure
az webapp create \
  --name finwise-api \
  --resource-group finwise-rg \
  --plan finwise-plan \
  --deployment-container-image-name yourregistry.azurecr.io/finwise-api:latest
```

### AWS ECS/Fargate

See [deployment documentation](docs/deployment.md) for detailed AWS deployment guide.

### CI/CD

GitHub Actions workflow automatically:
1. Runs tests on every PR
2. Builds Docker image
3. Deploys to staging on merge to `main`
4. Deploys to production after manual approval

---

## 🤝 Contributing

We welcome contributions! Please follow these guidelines:

### Development Workflow

1. Fork the repository
2. Create a feature branch: `git checkout -b feature/amazing-feature`
3. Make your changes
4. Write/update tests
5. Ensure tests pass: `dotnet test`
6. Ensure coverage stays above 80%
7. Commit with conventional commits: `git commit -m 'feat: add amazing feature'`
8. Push to your fork: `git push origin feature/amazing-feature`
9. Open a Pull Request

### Commit Convention

We follow [Conventional Commits](https://www.conventionalcommits.org/):

- `feat:` - New feature
- `fix:` - Bug fix
- `docs:` - Documentation changes
- `style:` - Code style changes (formatting, etc.)
- `refactor:` - Code refactoring
- `test:` - Adding or updating tests
- `chore:` - Maintenance tasks

### Code Style

- Follow C# coding conventions
- Use meaningful variable/method names
- Add XML documentation for public APIs
- Keep methods small and focused
- Write self-documenting code

### Pull Request Process

1. Update README.md with any new features
2. Update API documentation if endpoints changed
3. Ensure all tests pass and coverage is maintained
4. Request review from at least one maintainer
5. Address review feedback
6. Squash commits before merge

---

## 📚 Documentation

- [API Documentation](https://finwise-api.azurewebsites.net/swagger) - Swagger/OpenAPI
- [Architecture Guide](docs/architecture.md) - Detailed architecture decisions
- [Deployment Guide](docs/deployment.md) - How to deploy to various platforms
- [Contributing Guide](CONTRIBUTING.md) - How to contribute
- [Security Policy](SECURITY.md) - Security disclosure policy
- [Changelog](CHANGELOG.md) - Version history

---

## 📈 Roadmap

### Version 1.1 (Q1 2026)
- [ ] GraphQL endpoint as alternative to REST
- [ ] Real-time notifications with SignalR
- [ ] Export transactions to CSV/Excel
- [ ] Recurring transactions support
- [ ] Multi-currency support

### Version 2.0 (Q2 2026)
- [ ] Event Sourcing implementation
- [ ] CQRS with separate read/write databases
- [ ] Machine learning for transaction categorization
- [ ] Budget goals and tracking
- [ ] Mobile app (iOS/Android with MAUI)

---

## 🐛 Known Issues

See [Issues](https://github.com/yourusername/finwise-api/issues) page for current bugs and feature requests.

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## 🙏 Acknowledgments

- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) by Robert C. Martin
- [Domain-Driven Design](https://www.domainlanguage.com/ddd/) by Eric Evans
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core Documentation](https://docs.microsoft.com/ef/core)

---

## 📞 Support

- 📧 Email: support@finwise.com
- 💬 Discussions: [GitHub Discussions](https://github.com/yourusername/finwise-api/discussions)
- 🐛 Bug Reports: [GitHub Issues](https://github.com/yourusername/finwise-api/issues)
- 📖 Documentation: [Wiki](https://github.com/yourusername/finwise-api/wiki)

---

## ⭐ Star History

[![Star History Chart](https://api.star-history.com/svg?repos=yourusername/finwise-api&type=Date)](https://star-history.com/#yourusername/finwise-api&Date)

---

<div align="center">

**Built with ❤️ using .NET 10**

[⬆ Back to Top](#finwise-api)

</div>