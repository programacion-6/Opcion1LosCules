namespace Opcion1LosCules;

public abstract class AManager<T>
{
    private readonly List<T> _items;
    private readonly Validator<T> _validator;
    private readonly IStorage<T> _storage;

    public AManager(IStorage<T> storage, Validator<T> validator)
    {
        _items = new List<T>();
        _validator = validator;
        _storage = storage;
        LoadItemsFromDB();
    }

    public void AddItem(T item){
        _validator.Validate(item);
        if (!_items.Contains(item))
        {
            _items.Add(item);
            SaveItemsToDB();
        }
    }

    public abstract void UpdateItem(T item);

    public void RemoveItem(T item)
    {
        if (_items.Contains(item))
        {
            _items.Remove(item);
            SaveItemsToDB();
        }
    }

    private void LoadItemsFromDB()
    {
        var itemsFromJson = _storage.Load();
        _items.AddRange(itemsFromJson);
    }

    private void SaveItemsToDB()
    {
        _storage.Save(_items);
    }
}
