# APPWeb-PracticePack

*Aclaracción*: Este es solo un TEMPLATE, no he subido el codigo por que aun no lo termino. Lo estare subiendo durante el transcurso del día de hoy.
Perdonar los inconvenientes.

# PracticePackMVC - ASP.NET Core MVC Frontend

PracticePackMVC is a web-based frontend interface built with **ASP.NET Core MVC**, designed to interact with the **PracticePack serverless API** (hosted on AWS Lambda). It consumes backend services via **HTTP calls** and is hosted in **Amazon ECS using Fargate** for scalable, containerized deployment.

---

## 📚 Overview

This project is responsible for the user-facing interface of the PracticePack ecosystem. It provides:

- User registration & login
- Product browsing & details
- Cart and checkout flows
- Order tracking and payment status

It works as a client for the **PracticePack AWS Lambda API**.

---

## 🌐 Architecture

```plaintext
Browser
   |
   v
ASP.NET Core MVC (PracticePackMVC)
   |
   |--- Controllers / Views / Models
   |
   |--- HttpClient Services
   v
AWS API Gateway (connected to Lambda endpoints)
   |
   v
Lambda Functions (PracticePack API)
   |
   v
Amazon RDS (SQL Server)
```

---

## 🚀 Deployment Target

This application is packaged as a **Docker container** and deployed to **AWS ECS with Fargate**.

### Fargate Benefits:
- No server management
- Auto-scaling
- Pay-per-use model

---

## ⚖️ Technologies Used

- **ASP.NET Core MVC (.NET 8)**
- **Razor Views + Bootstrap**
- **HttpClient Factory** to consume Lambda API
- **Docker** for container packaging
- **AWS ECS with Fargate** for hosting
- **AutoMapper** for mapping ViewModels to DTOs

---

## 📓 Entities

Mirrors the backend Lambda API:

```csharp
User: Id, Username, Email, Password, Role
Person: Id, UserId, Name, Lastname, Phone
Product: Id, Name, Description, Price, Image
Order: Id, UserId, OrderItems[], Total
Payment: Id, OrderId, Status, Method
```

---

## 📂 Project Structure

```plaintext
/PracticePackMVC
  /Controllers
    - AccountController.cs
    - ProductController.cs
    - OrderController.cs
  /Models
    - ViewModels (UserVM, ProductVM, OrderVM)
    - DTOs (for API consumption)
  /Views
    - Shared (Layout, PartialViews)
    - Product, Order, Account
  /Services
    - IApiService.cs
    - LambdaApiService.cs
  /wwwroot
    - CSS / JS / Images
  /Dockerfile
  appsettings.json
```

---

## 🛠️ Configuration

Set Lambda API URLs in `appsettings.json`:
```json
"ApiSettings": {
  "BaseUrl": "https://your-api-id.execute-api.us-east-1.amazonaws.com",
  "LoginEndpoint": "/auth/login",
  "ProductEndpoint": "/products",
  "OrderEndpoint": "/orders",
  "PaymentEndpoint": "/payments"
}
```

---

## 🏜️ Deployment Instructions

### Docker Image:
```bash
docker build -t PracticePackmvc .
```

### Push to ECR:
```bash
aws ecr create-repository --repository-name PracticePackmvc
aws ecr get-login-password | docker login --username AWS --password-stdin <ecr-repo-url>
docker tag PracticePackmvc <ecr-repo-url>:latest
docker push <ecr-repo-url>:latest
```

### ECS Fargate:
- Create a Task Definition with container spec
- Create a Service pointing to that task
- Use an Application Load Balancer (ALB)

---

## 🚒 API Consumption

All data is retrieved through secure calls to the PracticePack Lambda API.
- JWT tokens are stored in cookies/session
- Sent via `Authorization: Bearer <token>` header
- JSON payloads are mapped from ViewModels → DTOs → API

---

## 🌟 Highlights

- Clean MVC separation of concerns
- Stateless & scalable via ECS Fargate
- Secure JWT-based API communication
- Easy to maintain and extend

---

> This project completes the full stack delivery system of PracticePack, integrating Lambda backend with a robust MVC frontend ✨

