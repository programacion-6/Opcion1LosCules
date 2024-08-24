namespace Opcion1LosCules;

using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class BooksManager
{
    private readonly List<Book> _books;
    private readonly BookValidator _bookValidator;

    private readonly string _filePath = "src/DataBase/BookStorage.json";

    public BooksManager()
    {
        _books = new List<Book>();
        _bookValidator = new BookValidator();
        LoadBooksFromDB(_filePath);
    }
    public void AddBook(Book book)
    {
        _bookValidator.Validate(book);
        if (!_books.Contains(book))
        {
            _books.Add(book);
            SaveBooksToDB(_filePath);
        }
    }

    public void UpdateBook(Book book)
    {
        
        var existingBook = _books.FirstOrDefault(b => b.Title == book.Title);
        
        if (existingBook != null)
        {
            existingBook.Author = book.Author;
            existingBook.ISBN = book.ISBN;
            existingBook.Genre = book.Genre;
            existingBook.PublicationYear = book.PublicationYear;
            existingBook.DueDate = book.DueDate;
            existingBook.ReturnDate = book.ReturnDate;
            existingBook.IsBorrowed = book.IsBorrowed;
            SaveBooksToDB(_filePath);
        }
    }

    public void RemoveBook(Book book)
    {
        if (_books.Contains(book))
        {
            _books.Remove(book);
            SaveBooksToDB(_filePath);
        }
    }

    public List<Book> GetAllBooks()
    {
        return _books;
    }

    private void LoadBooksFromDB(string filePath)
    {
        if (File.Exists(filePath))
        {
            var jsonData = File.ReadAllText(filePath);
            var booksFromJson = JsonConvert.DeserializeObject<List<Book>>(jsonData);

            if (booksFromJson != null)
            {
                _books.AddRange(booksFromJson);
            }
        }
        else
        {
            throw new FileNotFoundException($"El archivo {filePath} no fue encontrado.");
        }
    }

    private void SaveBooksToDB(string filePath)
    {
        var jsonData = JsonConvert.SerializeObject(_books, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
    }
}