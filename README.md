# EduMart - E-commerce Web Application

## Overview
EduMart is an ASP.NET MVC e-commerce web application designed to manage and sell online courses (referred to as "Skills"). The application allows users to browse, purchase, and manage courses, while administrators can manage mentors, platforms, and course organizers. The application also includes features like user authentication, shopping cart functionality, and order management.

## Features
- **User Authentication**: Users can register, log in, and manage their profiles. Roles include Admin and User.
- **Course Management**: Admins can create, update, and delete courses (Skills), including details like course name, description, price, start/end dates, and associated mentors.
- **Shopping Cart**: Users can add courses to their shopping cart, view the cart, and proceed to checkout.
- **Order Management**: Users can view their order history, and admins can view all orders.
- **Mentor Management**: Admins can manage mentors, including their profiles and the courses they are associated with.
- **Platform Management**: Admins can manage platforms where courses are hosted.
- **Course Organizer Management**: Admins can manage organizations that organize the courses.
- **Search and Filter**: Users can search for courses by name or description.

## Technologies Used
- **ASP.NET Core MVC**: The application is built using the ASP.NET Core MVC framework.
- **Entity Framework Core**: Used for database operations and migrations.
- **Identity Framework**: Handles user authentication and authorization.
- **Bootstrap**: Used for front-end styling and responsive design.
- **SQL Server**: The database used to store application data.
- **jQuery**: Used for client-side scripting and AJAX requests.

## Directory Structure
```
toimur678-aspnet-mvc-ecommerce-webapp/
|-- EduMart.sln
|-- EduMart/
    |-- Controllers/
    |-- Data/
    |-- Migrations/
    |-- Models/
    |-- Properties/
    |-- Views/
    |-- wwwroot/
```

## Getting Started

### Prerequisites
- .NET 8.0 SDK
- Visual Studio 2022 or later
- SQL Server (LocalDB or SQL Express)

### Installation
1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-repo/toimur678-aspnet-mvc-ecommerce-webapp.git
   ```
2. **Open the solution in Visual Studio**:
   - Open `EduMart.sln` in Visual Studio.
3. **Configure the database**:
   - Update the connection string in `appsettings.json` to point to your SQL Server instance.
   - Run the following commands in the Package Manager Console to apply migrations:
     ```bash
     Update-Database
     ```
4. **Seed the database**:
   - The application includes a seed method in `AppDbInitializer.cs` to create initial roles and users. Run the application to seed the database.
5. **Run the application**:
   - Press `F5` in Visual Studio to run the application.

### Default Users
- **Admin User**:
  - Email: `admin@gmail.com`
  - Password: `admin@1234`
- **Regular User**:
  - Email: `user@gmail.com`
  - Password: `user@1234`

## Usage
- **Admin Role**: Admins can manage courses, mentors, platforms, and course organizers. They can also view all orders.
- **User Role**: Users can browse courses, add them to their shopping cart, and place orders. They can also view their order history.

## Contributing
Contributions are welcome! Please fork the repository and create a pull request with your changes.

## Acknowledgments
- ASP.NET Core Documentation
- Bootstrap Documentation
- Entity Framework Core Documentation

## Contact
For any questions or issues, please open an issue on the GitHub repository.

---

**Note**: This is a sample project for educational purposes. It is not intended for production use without further testing and security enhancements.
