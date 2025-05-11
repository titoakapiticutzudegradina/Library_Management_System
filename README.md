# 🏃‍♂️ Running Instructions for Library Management System
This document provides all necessary steps to configure, build, and run the **Library Management System** developed in C#.

---

## ✅ Prerequisites

Make sure you have the following installed:
- [.NET 6.0 SDK or later](https://dotnet.microsoft.com/download)
- A C#-compatible IDE (Visual Studio 2022+, Rider, or VS Code with C# extension)
- Newtonsoft.Json version **13.0.3**

## 📌 How to Use the Application

When you run the application, a **console-based menu** will appear with the following options:
- Login as the Administrator
- Login as a User
- Register a new User

### 🧑‍💼 Administrator Options
- 📚 **View all books** in the library  
- ➕ **Add** a new book  
- 🗑️ **Remove** an existing book  
- ✏️ **Update** book information  
- 🔍 **Search** for books by:
  - **Title** or **Author**
  - **Number of available copies**

---
### 👤 User Options
- 📖 **View** all books in the library  
- 📥 **Lend** (borrow) a book  
- 📤 **Return** a borrowed book  
- 📚 **View all books currently borrowed**

## ✨ New Functionality Added

The new functionality added to this application is the **support for multiple users** in the system.

As explained above, each user can register and log in individually. With this enhancement:

- The system can **track exactly which books are borrowed by which user**.
- Each user has their own view of borrowed books.
- The application now reflects more **real-life library behavior**, where each member has a unique borrowing history.

This improvement makes the system significantly more realistic and useful for actual library scenarios.
