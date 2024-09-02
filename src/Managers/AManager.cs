namespace Opcion1LosCules;

public abstract class AManager<T>
{
    public List<T> Items;
    private readonly Validator<T> _validator;
    private readonly IStorage<T> _storage;

    public AManager(IStorage<T> storage, Validator<T> validator)
    {
        Items = new List<T>();
        _validator = validator;
        _storage = storage;
        LoadItemsFromDB();
    }

    public void AddItem(T item){
        _validator.Validate(item);
        if (!Items.Contains(item))
        {
            Items.Add(item);
            SaveItemsToDB();
        }
    }

    public abstract void UpdateItem(T item);

    public void RemoveItem(T item)
    {
        if (Items.Contains(item))
        {
            Items.Remove(item);
            SaveItemsToDB();
        }
    }

    protected void LoadItemsFromDB()
    {
        var itemsFromJson = _storage.Load();
        Items.AddRange(itemsFromJson);
    }

    protected void SaveItemsToDB()
    {
        _storage.Save(Items);
    }
}
