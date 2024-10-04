// File: Books.cs
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Libraryms
{
    public class Books : IBooks
    {
        // Dictionary to store book details
        private Dictionary<int, (string, string)> bookDictionary = new Dictionary<int, (string, string)>();

        // List of predefined book categories
        private List<string> bookCategories = new List<string> { "Fantasy", "Action", "Comedy", "Science", "History" };

        // Method to add book details
        public void AddBooks()
        {
            try
            {
                int bookId;

                // Book ID validation
                while (true)
                {
                    Console.Write("Enter Book ID (Numeric, up to 7 digits): ");
                    string input = Console.ReadLine().Trim();

                    // Validate Book ID: numeric, up to 7 digits, and no special characters
                    if (string.IsNullOrEmpty(input) || input.Length > 7 || !Regex.IsMatch(input, @"^[1-9]\d{0,6}$"))
                    {
                        Console.WriteLine("Invalid Book ID. It should be a number up to 7 digits, and cannot be empty or contain special characters.");
                        continue;
                    }

                    // Parse the validated input to an integer
                    bookId = int.Parse(input);

                    // Check if the book ID already exists
                    if (bookDictionary.ContainsKey(bookId))
                    {
                        Console.WriteLine("Book ID already exists. Please enter a unique Book ID.");
                        continue;
                    }
                    break;
                }

                // Book Name validation
                string bookName;
                while (true)
                {
                    Console.Write("Enter Book Name (Alphabetic, max 40 characters): ");
                    bookName = Console.ReadLine().Trim();

                    // Validate Book Name: no leading spaces, no special characters, no digits, and up to 40 characters
                    if (string.IsNullOrWhiteSpace(bookName) || bookName.Length > 40 || !Regex.IsMatch(bookName, @"^[A-Za-z][A-Za-z\s]{0,39}$"))
                    {
                        Console.WriteLine("Invalid Book Name. It should not start with a space, should be alphabetic, up to 40 characters, and cannot contain special characters or digits.");
                        continue;
                    }
                    break;
                }

                // Category selection
                string bookCategory;
                while (true)
                {
                    Console.WriteLine("Select Book Category: ");
                    for (int i = 0; i < bookCategories.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {bookCategories[i]}");
                    }
                    Console.Write("Enter category number: ");
                    if (!int.TryParse(Console.ReadLine(), out int categoryIndex) || categoryIndex < 1 || categoryIndex > bookCategories.Count)
                    {
                        Console.WriteLine("Invalid category selection. Please enter a valid number corresponding to the category.");
                        continue;
                    }

                    // Get the selected category
                    bookCategory = bookCategories[categoryIndex - 1];
                    break;
                }

                // Adding validated book details to the dictionary
                bookDictionary.Add(bookId, (bookName, bookCategory));
                Console.WriteLine("Book added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Method to edit existing book details
        public void EditBook(int id)
        {
            if (bookDictionary.ContainsKey(id))
            {
                string newBookName;
                while (true)
                {
                    Console.Write("Enter New Book Name (Alphabetic, max 40 characters): ");
                    newBookName = Console.ReadLine().Trim();

                    if (string.IsNullOrWhiteSpace(newBookName) || newBookName.Length > 40 || !Regex.IsMatch(newBookName, @"^[A-Za-z][A-Za-z\s]{0,39}$"))
                    {
                        Console.WriteLine("Invalid Book Name. It should not start with a space, should be alphabetic, up to 40 characters, and cannot contain special characters or digits.");
                        continue;
                    }
                    break;
                }

                // Category selection
                string newBookCategory;
                while (true)
                {
                    Console.WriteLine("Select New Book Category: ");
                    for (int i = 0; i < bookCategories.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {bookCategories[i]}");
                    }
                    Console.Write("Enter category number: ");
                    if (!int.TryParse(Console.ReadLine(), out int categoryIndex) || categoryIndex < 1 || categoryIndex > bookCategories.Count)
                    {
                        Console.WriteLine("Invalid category selection. Please enter a valid number corresponding to the category.");
                        continue;
                    }

                    newBookCategory = bookCategories[categoryIndex - 1];
                    break;
                }

                bookDictionary[id] = (newBookName, newBookCategory);
                Console.WriteLine("Book details updated successfully.");
            }
            else
            {
                Console.WriteLine("Book ID not found.");
            }
        }

        // Method to delete a book by ID
        public void DeleteBook(int id)
        {
            if (bookDictionary.Remove(id))
            {
                Console.WriteLine("Book deleted successfully.");
            }
            else
            {
                Console.WriteLine("Book ID not found.");
            }
        }

        // Method to get details of a single book by ID
        public void GetBookDetails()
        {
            Console.Write("Enter Book ID to retrieve details: ");
            if (int.TryParse(Console.ReadLine(), out int bookId) && bookDictionary.ContainsKey(bookId))
            {
                var book = bookDictionary[bookId];
                Console.WriteLine($"Book ID: {bookId}, Name: {book.Item1}, Category: {book.Item2}");
            }
            else
            {
                Console.WriteLine("Book ID not found.");
            }
        }

        // Method to view all book details
        public void ViewAllBooks()
        {
            if (bookDictionary.Count == 0)
            {
                Console.WriteLine("No books available in the library.");
                return;
            }

            Console.WriteLine("Book ID | Book Name | Book Category");
            Console.WriteLine("-----------------------------------");

            foreach (var book in bookDictionary)
            {
                Console.WriteLine($"{book.Key} | {book.Value.Item1} | {book.Value.Item2}");
            }
        }
    }
}
