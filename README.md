# ECommerceApp

A simple **ASP.NET MVC e-commerce application** using **Dapper** for data access.  
Supports Products and Categories with CRUD operations, soft delete, and clean MVC architecture.

---

## Features

- Products & Categories management  
- Soft delete for Products  
- Create, Read, Update, Delete (CRUD) operations  
- Dapper as ORM
- Separate **Entities** and **DTOs**  
- Bootstrap 5 UI with icons for actions  
- Date formatting and serial numbers in tables  
- Clean architecture: Controller → Service → Repository → DapperContext

---

## Technologies Used

- ASP.NET Core MVC   
- Dapper  
- SQL Server  
- Bootstrap 5 

---

## Database Setup

### 1. Create Database

```sql
CREATE DATABASE ECommerceDB;
GO
USE ECommerceDB;
GO

CREATE TABLE Category (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Product (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    Price DECIMAL(18,2) NOT NULL,
    CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    IsDeleted BIT NOT NULL DEFAULT 0
);

INSERT INTO Categories (Name) VALUES ('Electronics'), ('Clothing'), ('Books');

INSERT INTO Products (Name, Description, Price, CategoryId)
VALUES
('Laptop', 'High-end gaming laptop', 1500, 1),
('T-Shirt', 'Cotton T-shirt', 25, 2),
('C# Programming Book', 'Learn C# with examples', 40, 3);

 ```

## Project Setup

### 1. Clone the repository:
```https://github.com/kokonaing-dev/MiniEcommerce-AspNetDapperCrud.git```

### 2. Open in Visual Studio or your prefer IDE

### 3. Update DapperContext connection string to your SQL Server:
```  
"ConnectionStrings": {
    "DefaultConnection": "Server=your-server;Database=ECommerceDB;User ID=your-userid;Password=your-password;TrustServerCertificate=True;"
 }
 ```
 ### 4. Restore NuGet packages:
 ```dotnet restore```

 ### 5. Run the application:
 ```dotnet run```

