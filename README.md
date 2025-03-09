# ImproveByFaz

**ImproveByFaz - Project Vision, Architecture, and API Documentation**

**📌 Vision Statement**

The **ImproveByFaz** project is designed to revolutionize personalized learning by enabling students to independently review and correct their previously answered incorrect questions. The goal is to provide an intuitive and structured learning experience where students can strengthen their understanding through targeted revision. By leveraging modern web technologies, the platform ensures an efficient and scalable approach to improving student engagement and academic success.

**Core Objectives:**

- **Enhance Learning Outcomes**: Allow students to review their misconceptions and improve their understanding through structured revision.
- **Provide a Scalable and Maintainable Solution**: Built on a modern, high-performance tech stack to ensure longevity and future adaptability.
- **Facilitate Seamless Teacher-Student Interaction**: Enables teachers to assign extra work efficiently to students who need reinforcement.
- **Ensure a Reliable and Efficient System**: Implements best practices in software architecture, database management, and cloud deployment.

**🏛 Application Architecture**

The **ImproveByFaz** project follows the **Clean Architecture** pattern to ensure a well-structured, maintainable, and scalable solution.

**📂 Project Structure:**

📂 ImproveByFaz

│

├── 📂 ImproveByFaz.Domain (Entities, Value Objects, Interfaces)

├── 📂 ImproveByFaz.Application (CQRS, DTOs, Services, Validators)

├── 📂 ImproveByFaz.Infrastructure (Database, Repositories, External Services)

├── 📂 ImproveByFaz.API (Controllers, Middlewares, Configurations, Extensions)

└── 📂 ImproveByFaz.Tests (Unit & Integration Tests)

**💡 Why This Architecture?**

- **Separation of Concerns**: Business logic is kept separate from data access and API layers.
- **Scalability**: Easily extendable to accommodate future enhancements like AI-driven learning.
- **Testability**: Enables unit testing at each layer without dependency conflicts.
- **Maintainability**: Changes in one layer (e.g., switching databases) do not affect others.

**💻 Technologies Used**

The project leverages a robust and scalable architecture designed to meet modern development standards while ensuring high performance and maintainability.

**Backend Technologies**

| **Technology** | **Purpose** |
| --- | --- |
| **ASP.NET Core 8.0** | Provides a high-performance, cross-platform web API framework. |
| **Entity Framework Core** | Simplifies database interactions with LINQ-based queries and migrations. |
| **MediatR (CQRS Pattern)** | Implements Command-Query Responsibility Segregation (CQRS) to separate business logic efficiently. |
| **FluentValidation** | Ensures structured and reliable input validation across the system. |
| **Serilog** | Enables structured logging for debugging, performance monitoring, and system auditing. |

**Database & Persistence**

| **Technology** | **Purpose** |
| --- | --- |
| **SQL Server** | Stores structured application data with relational database management. |
| **EF Core Migrations** | Manages schema evolution and ensures seamless updates. |
| **Automatic Database Seeding** | Ensures a consistent test environment by reloading structured data on each startup. |

**API Documentation & Testing**

| **Technology** | **Purpose** |
| --- | --- |
| **Swagger UI** | Provides interactive API documentation and testing. |
| **Postman** | Used for testing and validating API endpoints. |

**Development & Deployment**

| **Technology** | **Purpose** |
| --- | --- |
| **GitHub** | Version control and collaboration. |
| **Docker (Planned Feature)** | Containerization for environment consistency and deployment portability. |
| **Azure DevOps (Planned Feature)** | Implements Continuous Integration & Continuous Deployment (CI/CD). |

**📌 API Endpoints and Usage**

**🔍 1️⃣ Retrieve Topics with Incorrect Answers**

- **Endpoint:** GET /api/topics/misconceptions
- **Description:** Returns a list of topics with subtopics where the student has misconceptions.
- **Response Example:**

\[

{

"topic": "Algebra",

"subTopics": \[

{

"name": "Quadratic Equations",

"misconceptionCount": 3

}

\]

}

\]

**✍ 2️⃣ Retrieve and Answer a Question**

- **Endpoint:** GET /api/questions/{subTopicId}
- **Description:** Fetches a question from a specific subtopic that the student got wrong.
- **Response Example:**

{

"questionId": 123,

"imageUrl": "<https://cdn.eedi.com/questions/q1.png>",

"options": \["A", "B", "C", "D"\],

"correctAnswer": "B"

}

**📌 3️⃣ Submit an Answer**

- **Endpoint:** POST /api/questions/{questionId}/answer
- **Description:** Allows a student to submit an answer and receive feedback.
- **Request Body:**

{

"selectedAnswer": "C"

}

- **Response Example:**

{

"isCorrect": false,

"explanation": "Quadratic equations follow a specific pattern..."

}

**🚀 How to Download & Use the API for Testing**

**1️⃣ Clone the Repository**

git clone <https://github.com/dotnetdeveloper20xx/ImproveByFaz.git>

cd ImproveByFaz

**2️⃣ Configure Database Connection**

Modify appsettings.json in **ImproveByFaz.API**:

"ConnectionStrings": {

"DefaultConnection": "Server=localhost;Database=ImproveByFazDb;User Id=sa;Password=YourStrong!Pass;TrustServerCertificate=True"

}

**3️⃣ Apply Database Migrations & Seed Data**

dotnet ef database update --project ImproveByFaz.Infrastructure --startup-project ImproveByFaz.API

**4️⃣ Run the Application**

dotnet run --project ImproveByFaz.API

**5️⃣ Open Swagger UI for API Testing**

Once the application is running, access Swagger at:

<http://localhost:5000/swagger/index.html>

**🌟 Conclusion**

The **ImproveByFaz** project is a forward-thinking educational platform that leverages modern software architecture to enhance student learning. By continuously evolving with advanced features and cloud scalability, the system aspires to become a leading AI-driven **personalized learning assistant**.

📌 **Next Steps:**

- **Showcase this project on GitHub** with a detailed README.md.
- **Deploy a live version to Azure or AWS**.
- **Enhance with authentication, a frontend UI, and advanced analytics**.

 
