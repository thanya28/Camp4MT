// File: Program.cs
using System;

namespace Libraryms
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Books class
            Books library = new Books();
            bool continueProgram = true;

            while (continueProgram)
            {
                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Get Book Details");
                Console.WriteLine("3. Edit Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. View All Books");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                // User's choice
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        library.AddBooks();
                        break;

                    case 2:
                        library.GetBookDetails();
                        break;

                    case 3:
                        Console.Write("Enter Book ID to edit: ");
                        if (int.TryParse(Console.ReadLine(), out int editId))
                        {
                            library.EditBook(editId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Book ID.");
                        }
                        break;

                    case 4:
                        Console.Write("Enter Book ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            library.DeleteBook(deleteId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Book ID.");
                        }
                        break;

                    case 5:
                        library.ViewAllBooks();
                        break;

                    case 6:
                        continueProgram = false;
                        Console.WriteLine("Exiting Library Management System.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
    }
}
