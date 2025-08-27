# 📌 Task Manager API  

A simple **Task Manager API** built with **.NET 7 / C#** that allows users to create, update, delete, and manage tasks with priorities and completion status.  

---

## 🚀 Features  

- Create new tasks with title, description, and priority.  
- Update task details (partial & full updates).  
- Mark tasks as complete/incomplete.  
- Delete tasks.  
- Get all tasks or a single task by ID.  
- AutoMapper for DTO ↔ Model mapping.  
- Repository pattern for clean architecture.  
- Swagger UI for API documentation.  

---

## 🛠️ Technologies Used  

- **.NET 8 / ASP.NET Core Web API**  
- **C#**  
- **Entity Framework Core (InMemory / SQL Server)**  
- **AutoMapper**  
- **Repository Pattern**  
- **Swagger / Swashbuckle**  

---

## 📂 Project Structure  

TaskManager/
│── Controllers/
│ └── TaskController.cs
│
│── DTOs/
│ ├── CreateTask.cs
│ ├── ReadTask.cs
│ └── UpdateTask.cs
│
│── Mapping/
│ └── AutoMapper.cs
│
│── Models/
│ ├── Items.cs
│ └── Enum.cs
│
│── Repositories/
│ ├── ITaskRepo.cs
│ └── TaskRepo.cs
│
│── Program.cs
│── appsettings.json


## ⚙️ Installation & Setup  

1. **Clone the repository:**  
```bash
git clone https://github.com/hakeem119 /TaskManagerApi.git
cd TaskManagerApi
Restore dependencies:


bash
Copy code
https://localhost:5001/swagger
📌 Example Endpoints
✅ Create a Task
POST /api/tasks

json
Copy code
{
  "title": "Learn .NET",
  "description": "Practice building Web APIs",
  "priority": 2
}
📖 Get All Tasks
GET /api/tasks

✏️ Update a Task
PATCH /api/tasks/{id}

json
Copy code
{
  "title": "Learn ASP.NET Core Web API"
}
🔄 Toggle Complete
PATCH /api/tasks/{id}/complete

❌ Delete a Task
DELETE /api/tasks/{id}

📸 Swagger Preview
When you run the project, Swagger UI will be available to test all endpoints easily.

🤝 Contributing
Pull requests are welcome! For major changes, please open an issue first to discuss what you would like to change.

📜 License
This project is licensed under the MIT License.


