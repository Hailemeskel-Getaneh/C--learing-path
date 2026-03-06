# Unit 09 — Database-First Architecture Skeleton

This folder contains a conceptual skeleton of how to structure a large-scale Enterprise project using the concepts you've learned.

## Project Structure (The "Clean" Way)

If you were to open this in Visual Studio, it should be divided into 4 projects (folders):

### 📁 1. MyApp.Domain (POCO Classes)
- **Purpose:** Pure C# classes (Entities). No dependencies.
- **Example:** `User.cs`, `Product.cs`.

### 📁 2. MyApp.Data (Persistence Layer)
- **Purpose:** Where the database "lives."
- **Contains:** `AppDbContext`, `Repositories/`, `UnitOfWork.cs`.

### 📁 3. MyApp.Services (Business Logic)
- **Purpose:** Where the choices are made.
- **Contains:** `IOrderService`, `CalculationEngine.cs`.

### 📁 4. MyApp.API (Web API)
- **Purpose:** The entry point (Controllers).
- **Contains:** `Controllers/`, `Program.cs`, `appsettings.json`.

---

## 🚀 Practical Challenge
Try to build a small **Ticketing System**:
1. Create a `Ticket` entity (Id, Title, Description, Status).
2. Create a `TicketRepository`.
3. Create a `UnitOfWork` that manages the TicketRepository.
4. Create an API Controller that uses the UnitOfWork to add a ticket.

**Checklist for Review:**
- [ ] Is it Async?
- [ ] Does it use IQueryable for searches?
- [ ] Is the DbContext injected via DI?
- [ ] Are the C# strengths (Interfaces/Generics) implemented?

---
*Next Step: Once you've attempted this, show the code to your manager or mentor for architectural review.*
