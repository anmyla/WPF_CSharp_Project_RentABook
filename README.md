This simple WPF project is a part of our Interactive Systems course.
It is written in c#, uses Entity Framework for its database, and follows the CVVM model. 

---------------------------------------------DOCUMENTATION--------------------------------------------------------

A "Rent a Book" WPF project is a desktop application designed for managing the rental of books within a library or bookstore setting. 
The project leverages Windows Presentation Foundation (WPF) to provide a rich, interactive user interface. 

Project Description

Overview
The "Rent a Book" WPF application allows users to browse, rent, and return books. 
It manages the book inventory, tracks rental transactions, and maintains user details. 
The application is built with a clean and user-friendly interface to ensure ease of use for both staff and customers.

Key Features

Book Management:
Add New Books: Allows administrators to add new books to the inventory, including details such as title, author, genre, publication year, etc.
Edit Book Details: Provides functionality to update existing book information.
Delete Books: Enables the removal of books that are no longer available.

Genre Management:
List Genres: Displays a list of available genres.
Add/Edit/Delete Genres: Allows for the management of genres to categorize books.

User Management:
Register Users: Facilitates the registration of new users who wish to rent books.
Edit User Information: Allows for updating user details.
Delete Users: Removes users from the system.

Rental Management:
Rent Books: Enables users to rent available books, recording the rental date and due date.
Return Books: Processes the return of rented books and updates the inventory.
View Rental History: Provides a history of all rentals for each user.

Search Functionality:
Search Books: Allows users to search for books by title, author, genre, or ISBN.
Search Users: Enables searching for users by name or ID.

Status Bar:
Displays real-time information about the number of books available, books rented, and overdue books.

User Interface
The application’s UI is designed using WPF, ensuring a modern and responsive design. The main window includes the following components:

Menu Bar:
File: Options to create new entries and exit the application.
Edit: Options for cutting, copying, and pasting information.
Help: Provides access to user guides and support.

Tool Bar:
Quick access buttons for adding books, users, and genres, as well as renting and returning books.

Status Bar:
Displays the number of books in various states (e.g., available, rented, overdue).

Main Content Area:
A grid or list view displaying books, users, or rental transactions based on the selected operation.
Details section to show the selected book or user details.

Database Integration
The application integrates with a database using Entity Framework to manage persistent data storage. 
The database stores information about books, users, genres, and rental transactions.
