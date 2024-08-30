using Opcion1LosCules;

public class Database : IDatabaseContext
{
    private static Database _instance;

    public static Database GetInstance()
    {
        if(_instance == null)
        {
            _instance = new Database();
        }
        return _instance;
    }
    
    public readonly Dictionary<string, Book> _bookStorage = [];
    public readonly Dictionary<string, Patron> _patronStorage = [];
    private readonly int _okCode = 200;
    private readonly int _badRequestCode = 400;

    public Task<int> Add<T>(T entity) where T : class
    {
        if (entity is Book book)
        {
            _bookStorage[book.Id.ToString()] = book;
            return Task.FromResult(_okCode);
        }
        else if (entity is Patron patron)
        {
            _patronStorage[patron.Id.ToString()] = patron;
            return Task.FromResult(_okCode);
        }
        else
        {
            throw new ArgumentException("Unsupported entity type");
        }
    }

    public Task<int> Update<T>(string id, T entity) where T : class
    {
        if (entity is Book book && _bookStorage.ContainsKey(id))
        {
            book.Id = _bookStorage[id].Id;
            _bookStorage[id] = book;
            return Task.FromResult(_okCode);
        }
        else if (entity is Patron patron && _patronStorage.ContainsKey(id))
        {
            patron.Id = _patronStorage[id].Id;
            _patronStorage[id] = patron;
            return Task.FromResult(_okCode);
        }
        else
        {
            throw new ArgumentException("Entity not found or unsupported entity type");
        }
    }

    public Task<int> Delete(string id)
    {
        if (_bookStorage.ContainsKey(id))
        {
            _bookStorage.Remove(id);
            return Task.FromResult(_okCode);
        }
        else if (_patronStorage.ContainsKey(id))
        {
            _patronStorage.Remove(id);
            return Task.FromResult(_okCode);
        }
        else
        {
            throw new ArgumentException("Entity not found or unsupported entity type");
        }
    }

    public Task<T> GetById<T>(string id) where T : class
    {
        if (typeof(T) == typeof(Book) && _bookStorage.ContainsKey(id))
        {
            return Task.FromResult(_bookStorage[id] as T);
        }
        else if (typeof(T) == typeof(Patron) && _patronStorage.ContainsKey(id))
        {
            return Task.FromResult(_patronStorage[id] as T);
        }
        else
        {
            return Task.FromResult<T>(null);
        }
    }

    public Task<IEnumerable<T>> GetAll<T>() where T : class
    {
        if (typeof(T) == typeof(Book))
        {
            return Task.FromResult(_bookStorage.Values.Cast<T>());
        }
        else if (typeof(T) == typeof(Patron))
        {
            return Task.FromResult(_patronStorage.Values.Cast<T>());
        }
        else
        {
            return Task.FromResult(Enumerable.Empty<T>());
        }
    }

}