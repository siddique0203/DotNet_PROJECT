-------------------------------------- Shifting Service Management System --------------------------------------

📌 Project Overview
The Shifting Service Management System (SSMS) is a RESTful Web API–based backend application developed as part of an Advanced .NET course project.
The system is designed to digitize and streamline the relocation (house/office shifting) process by connecting customers, shifting agencies, and administrators through a unified, transparent, and scalable platform.
In traditional shifting services, customers face difficulties in finding reliable agencies, comparing fair prices, tracking service progress, and ensuring accountability. At the same time, agencies struggle with request management, scheduling, team assignment, and communication.
SSMS addresses these challenges by providing a centralized API-driven solution that ensures clarity, automation, and real-time tracking throughout the entire service lifecycle.

🎯 Key Objectives
~ Build a RESTful Web API following industry best practices
~ Implement a clean N-Tier Architecture for scalability and maintainability
~ Go beyond basic CRUD by implementing real-world business functionalities
~ Ensure proper request/response handling, validation, and error management
~ Test and validate all APIs using Postman

🏗️ Architecture
The project follows a 3-Tier (N-Tier) Architecture:

1️⃣ Presentation Layer (API Controllers)
~ Handles HTTP requests and responses
~ Exposes RESTful endpoints
~ Returns JSON-formatted responses with proper HTTP status codes

2️⃣ Business Logic Layer (BLL / Services)
~ Contains all business rules and workflows
~ Manages booking flow, status transitions, quotations, and validations
~ Acts as an intermediary between controllers and data access

3️⃣ Data Access Layer (DAL / Repositories)
~ Manages database operations using Entity Framework
~ Handles CRUD and complex queries
~ Ensures separation of concerns and clean data handling

⚙️ Technologies Used
~ ASP.NET Web API
~ C#
~ Entity Framework (ORM)
~ SQL Server (Relational Database)
~ Postman (API Testing)
~ JSON (Request & Response Format)

🔑 Core Functionalities
CRUD operations are implemented but not counted toward functional marks.
✔️ Functionalities Beyond CRUD
~ Advanced Searching & Filtering. Filter shifting requests by date, status, location, and agency
~ Quotation & Booking Workflow. Agencies respond with quotations, Customers compare and confirm bookings
~ Workflow Automation. Automatic status transitions (Requested → Quoted → Confirmed → In Progress → Completed)
~ Real-Time Status Tracking. Customers can track preparation, team assignment, and shifting progress
~ Reporting & Logs. Service history, transaction logs, and activity tracking
~ Feedback & Rating System. Customers provide feedback after service completion

🗄️ Database Design
~ Relational database design using SQL Server
~ Well-defined entity relationships:
~ Customers
~ Agencies
~ Shifting Requests
~ Bookings
~ Payments
~ Feedback & Logs
~ Managed entirely through Entity Framework

🔐 API Standards & Best Practices
~ RESTful endpoint design
~ Proper use of HTTP methods:
~ GET – Fetch data
~ POST – Create resources
~ PUT – Update resources
~ DELETE – Remove resources
~ Standard HTTP status codes:
~ 200 OK, 201 Created, 400 Bad Request, 404 Not Found, 500 Internal Server Error
~ Input validation and structured error handling

🧪 API Testing
~ All endpoints were thoroughly tested using Postman, including:
~ Valid and invalid requests
~ JSON request/response validation
~ Status code verification
~ Workflow and edge-case testing

📈 Learning Outcomes
~ Practical experience with RESTful API design
~ Hands-on implementation of N-Tier architecture
~ Real-world workflow and business logic handling
~ Strong understanding of Entity Framework & SQL Server
~ API testing and debugging using Postman

🏆 Result
✅ Successfully completed as an Advanced .NET Course Project
🎯 Achieved 90% overall marks based on architecture, functionality, code quality, and viva evaluation
