# ImproveByFaz - API Documentation & Project Overview

## 📌 Project Title: ImproveByFaz API

## 📖 Summary
ImproveByFaz is an educational API that enables students to review and re-answer questions they previously got incorrect. The API provides structured learning improvements by allowing students to focus on their **misconceptions** and correct their understanding. The system is designed with scalability, performance, and maintainability in mind using **Clean Architecture** principles.

## 📂 Project Overview
ImproveByFaz is structured to follow industry best practices with **Clean Architecture**, ensuring separation of concerns between **Domain, Application, Infrastructure, and API Layers**.

### 🏛 **Architecture Used**: Clean Architecture
- **Why?**
  - **Scalability**: Supports growth and feature expansion without breaking existing code.
  - **Maintainability**: Easy updates without affecting core functionality.
  - **Testability**: Enables unit and integration testing at each layer.
- **Layers:**
  - **Domain**: Contains core business entities and rules.
  - **Application**: Handles **business logic (CQRS, DTOs, Use Cases, Validation, Services)**.
  - **Infrastructure**: Deals with **database persistence (EF Core), repositories, external services, caching, and logging**.
  - **API**: Provides endpoints for interaction with **frontend or external clients**.

---

## **API Endpoints**
This section outlines each API endpoint, including its **purpose, request format, and example responses**.

### **1️⃣ Retrieve Topics with Incorrect Answers**
- **Endpoint:** `GET /api/topics/misconceptions`
- **Purpose:** Retrieves topics where the student has incorrect answers.
- **Request Example:**
  ```http
  GET /api/topics/misconceptions
  ```
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

### **2️⃣ Retrieve Questions for a Subtopic**
- **Endpoint:** `GET /api/questions/{subTopicId}`
- **Purpose:** Fetches a previously incorrect question from a specific subtopic.
- **Request Example:**
  ```http
  GET /api/questions/5
  ```
- **Response Example:**
  ```json
  {
    "questionId": 123,
    "imageUrl": "https://cdn.eedi.com/questions/q5.png",
    "options": ["A", "B", "C", "D"],
    "correctAnswer": "B"
  }
  ```

### **3️⃣ Submit an Answer**
- **Endpoint:** `POST /api/questions/{questionId}/answer`
- **Purpose:** Allows a student to submit an answer.
- **Request Example:**
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
- **Purpose:** Returns the student's learning progress.
- **Response Example:**
  ```json
  {
    "studentId": 45,
    "topicsReviewed": 3,
    "totalQuestionsAttempted": 50,
    "improvementRate": "75%"
  }
  ```

---

## **Technologies Used**
### **Backend**
- **ASP.NET Core 8.0** → For API development
- **Entity Framework Core** → Database ORM
- **MediatR (CQRS)** → Command-Query Responsibility Segregation
- **FluentValidation** → Input validation
- **Serilog** → Logging to console and files
- **Redis (Optional)** → Caching for frequently accessed data

### **Database**
- **SQL Server** → Stores structured relational data
- **EF Core Migrations** → Schema versioning

### **Performance Enhancements**
- **Response Caching** → Reduces unnecessary database calls
- **Exception Handling Middleware** → Standardized error responses

### **Security Considerations**
Due to time constraints, **JWT authentication, pagination, and rate limiting were not implemented**, but they are crucial for a production-ready API:
- **JWT Authentication** → Ensures secure user access.
- **Pagination** → Optimizes large data retrieval.
- **Rate Limiting** → Prevents abuse by limiting excessive requests.
In a real-world application, these features would be **mandatory** before going live.

---

## **Next Steps & Future Enhancements**
If given more time, we could implement:
- **Microservices Architecture** for better scalability
- **AI-based Question Recommendations** for adaptive learning
- **GraphQL API** for flexible querying
- **WebSocket-based Real-time Updates** for instant feedback
- **Frontend UI (React/Blazor)** to visualize student progress

---

## **Conclusion**
ImproveByFaz is a well-architected, scalable, and maintainable API for improving student learning. With structured **CQRS, caching, and API versioning**, it is designed for **growth and future feature expansion**. While some security and performance optimizations were not implemented due to time constraints, they are **critical for a real-world production deployment**.



