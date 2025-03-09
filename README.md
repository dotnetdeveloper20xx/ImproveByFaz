# ImproveByFaz - Project Vision, Architecture, and API Documentation

## 📌 Vision Statement
The **ImproveByFaz** project is designed to revolutionize personalized learning by enabling students to independently review and correct their previously answered incorrect questions. The goal is to provide an intuitive and structured learning experience where students can strengthen their understanding through targeted revision. By leveraging modern web technologies, the platform ensures an efficient and scalable approach to improving student engagement and academic success.

## 📌 API Endpoints
This section provides a detailed overview of each API endpoint, explaining **what it does, why it exists, and how to use it**.

### **1️⃣ Retrieve Topics with Incorrect Answers**
- **Endpoint:** `GET /api/topics/misconceptions`
- **Purpose:** This endpoint retrieves a list of topics that contain subtopics where a student has previously answered questions incorrectly.
- **Why It Exists:** To help students focus on specific areas where they need improvement.
- **How to Use:** Send a `GET` request to `/api/topics/misconceptions`.
- **Response Example:**
```json
[
  {
    "topic": "Algebra",
    "subTopics": [
      {
        "name": "Quadratic Equations",
        "misconceptionCount": 3
      }
    ]
  }
]
```

### **2️⃣ Retrieve and Answer a Question**
- **Endpoint:** `GET /api/questions/{subTopicId}`
- **Purpose:** Fetches a question from a specific subtopic that the student previously got wrong.
- **Why It Exists:** Allows students to retry answering questions from topics where they made mistakes.
- **How to Use:** Replace `{subTopicId}` with a valid subtopic ID and send a `GET` request.
- **Response Example:**
```json
{
  "questionId": 123,
  "imageUrl": "https://cdn.eedi.com/questions/q1.png",
  "options": ["A", "B", "C", "D"],
  "correctAnswer": "B"
}
```

### **3️⃣ Submit an Answer**
- **Endpoint:** `POST /api/questions/{questionId}/answer`
- **Purpose:** Allows a student to submit an answer to a previously incorrect question.
- **Why It Exists:** Enables tracking of student progress and improvement.
- **How to Use:** Replace `{questionId}` with a valid question ID and send a `POST` request with the answer.
- **Request Body:**
```json
{
  "selectedAnswer": "C"
}
```
- **Response Example:**
```json
{
  "isCorrect": false,
  "explanation": "Quadratic equations follow a specific pattern..."
}
```

### **4️⃣ Retrieve Student Progress**
- **Endpoint:** `GET /api/students/{studentId}/progress`
- **Purpose:** Returns an overview of a student’s progress, including completed topics and improvement areas.
- **Why It Exists:** To give teachers and students insight into learning performance.
- **How to Use:** Replace `{studentId}` with a valid student ID and send a `GET` request.
- **Response Example:**
```json
{
  "studentId": 45,
  "topicsReviewed": 3,
  "totalQuestionsAttempted": 50,
  "improvementRate": "75%"
}
```

### **5️⃣ Get Explanation for a Question**
- **Endpoint:** `GET /api/questions/{questionId}/explanation`
- **Purpose:** Retrieves the explanation for a given question to help the student understand the correct answer.
- **Why It Exists:** Provides additional learning support to reinforce understanding.
- **How to Use:** Replace `{questionId}` with a valid question ID and send a `GET` request.
- **Response Example:**
```json
{
  "questionId": 123,
  "explanation": "Quadratic equations require factoring or using the quadratic formula."
}
```

### Core Objectives:

---

- **Enhance Learning Outcomes**: Allow students to review their misconceptions and improve their understanding through structured revision.
- **Provide a Scalable and Maintainable Solution**: Built on a modern, high-performance tech stack to ensure longevity and future adaptability.
- **Facilitate Seamless Teacher-Student Interaction**: Enables teachers to assign extra work efficiently to students who need reinforcement.
- **Ensure a Reliable and Efficient System**: Implements best practices in software architecture, database management, and cloud deployment.

---

## 🏛 Application Architecture
### **What Architecture Have We Used and Why?**
The **ImproveByFaz** project follows the **Clean Architecture** pattern. This design choice was made to ensure:
- **Separation of Concerns**: Business logic is kept separate from data access and API layers.
- **Scalability**: Easily extendable to accommodate future enhancements like AI-driven learning.
- **Testability**: Enables unit testing at each layer without dependency conflicts.
- **Maintainability**: Changes in one layer (e.g., switching databases) do not affect others.

### 📂 Project Structure:
```
📂 ImproveByFaz
│
├── 📂 ImproveByFaz.Domain (Entities, Value Objects, Interfaces)
├── 📂 ImproveByFaz.Application (CQRS, DTOs, Services, Validators)
├── 📂 ImproveByFaz.Infrastructure (Database, Repositories, External Services)
├── 📂 ImproveByFaz.API (Controllers, Middlewares, Configurations, Extensions)
└── 📂 ImproveByFaz.Tests (Unit & Integration Tests)
```

### **Other Architectures We Could Use Based on Infrastructure (Azure/AWS)**
Depending on where we host the application, different architectures could be utilized:

#### **1️⃣ Microservices Architecture (Recommended for AWS/Azure Kubernetes Service)**
- **When to Use:** If the project is expected to scale into multiple independent services.
- **How It Works:** Each module (e.g., Authentication, Learning Progress, Analytics) could be a separate microservice.
- **Infrastructure:** AWS ECS/Fargate, Azure Kubernetes Service (AKS), or Docker Containers.
- **Benefits:** High scalability, independent deployments, fault isolation.

#### **2️⃣ Serverless Architecture (Recommended for AWS Lambda/Azure Functions)**
- **When to Use:** If the system needs to run only on-demand without maintaining servers.
- **How It Works:** API endpoints can be deployed as **serverless functions**.
- **Infrastructure:** AWS Lambda with API Gateway, Azure Functions with Azure API Management.
- **Benefits:** Cost efficiency, automatic scaling, no infrastructure maintenance.

#### **3️⃣ Monolithic Architecture (Current Approach - Best for On-Prem or Small Deployments)**
- **When to Use:** Best for small-to-medium-sized applications with limited need for independent scaling.
- **How It Works:** A single deployable unit with all features bundled together.
- **Infrastructure:** Deployed on Azure App Service, AWS EC2, or an on-premise server.
- **Benefits:** Simple deployment, lower overhead, easier initial development.

---

## 💻 Technologies Used
The project leverages a robust and scalable architecture designed to meet modern development standards while ensuring high performance and maintainability.

### Backend Technologies
| **Technology** | **Purpose**  |
|---------------|-------------|
| **ASP.NET Core 8.0** | Provides a high-performance, cross-platform web API framework. |
| **Entity Framework Core** | Simplifies database interactions with LINQ-based queries and migrations. |
| **MediatR (CQRS Pattern)** | Implements Command-Query Responsibility Segregation (CQRS) to separate business logic efficiently. |
| **FluentValidation** | Ensures structured and reliable input validation across the system. |
| **Serilog** | Enables structured logging for debugging, performance monitoring, and system auditing. |

### Database & Persistence
| **Technology** | **Purpose** |
|--------------|------------|
| **SQL Server** | Stores structured application data with relational database management. |
| **EF Core Migrations** | Manages schema evolution and ensures seamless updates. |
| **Automatic Database Seeding** | Ensures a consistent test environment by reloading structured data on each startup. |

### API Documentation & Testing
| **Technology** | **Purpose** |
|--------------|------------|
| **Swagger UI** | Provides interactive API documentation and testing. |
| **Postman** | Postman be used for testing and validating API endpoints. |

### Development & Deployment
| **Technology** | **Purpose** |
|--------------|------------|
| **GitHub** | Version control and collaboration. |
| **Docker (Planned Feature)** | Containerization for environment consistency and deployment portability. |
| **Azure DevOps (Planned Feature)** | Implements Continuous Integration & Continuous Deployment (CI/CD). |

---

## 🌟 Conclusion
The **ImproveByFaz** project is a forward-thinking educational platform that leverages modern software architecture to enhance student learning. By continuously evolving with advanced features and cloud scalability, the system aspires to become a leading AI-driven **personalized learning assistant**.

📌 **Next Steps:**
- **Showcase this project on GitHub** with a detailed `README.md`.
- **Deploy a live version to Azure or AWS**.
- **Enhance with authentication, a frontend UI, and advanced analytics**.

