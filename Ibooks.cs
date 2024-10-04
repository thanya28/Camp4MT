
using System;

namespace Libraryms
{
    public interface IBooks
    {
        void AddBooks();
        void GetBookDetails();
        void EditBook(int id);
        void DeleteBook(int id);
        void ViewAllBooks();
    }
}
