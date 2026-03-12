# Roster-Management-PoC
A C# / .NET MVC application for employee scheduling and roster management, including a calendar generation and SQL database integration.

### **The Problem**
In a hospitality environment, staff scheduling was managed through personal text message threads. This sometimes led to confusion regarding shift coverage and holiday dates.

### **The Solution**
I developed this .NET MVC concept to create / edit staff data and automate the generation of a visual work calendar. In the future I intend to add a function where the calendar will display which staff members are working at what times.

### **Tech Highlights**
* **Dynamic Calendar Engine:** Created calendar logic using the C# `DateTime` library to generate monthly grids and eventually map employee shifts.
* **Relational Data Modeling:** Utilized Entity Framework Core, linking Employees, Roles, and eventually shift assignments.
* **Database Migrations:** See `/Migrations`. Ran an SQL server for the database on my own personal computer, so unfortunately previous data can't be seen. Used EF migrations for data.
* **MVC Architecture:** Used .NET Model-View-Controller to separate logic from the user interface.

### **Database Schema**
The project uses a database that establishes the `Employees` table with:
- `Id`: Key (Automatically incrementing after each staff creation)
- `Name`: String
- `Description`: Field for employee roles or notes

### **Project Status**
This repository serves as an Archive. Although the core logic and database architecture are implemented, the project is currently in a Proof-of-Concept state and is not connected to a live database.
