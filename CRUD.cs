public class ItemService
{
    private readonly IMongoCollection<Item> _items;

    public ItemService(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDB:ConnectionString"]);
        var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
        _items = database.GetCollection<Item>("Items");
    }

    public async Task<List<Item>> GetAllAsync() => await _items.Find(_ => true).ToListAsync();

    public async Task<Item> GetAsync(string id) => await _items.Find(i => i.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Item item) => await _items.InsertOneAsync(item);

    public async Task UpdateAsync(string id, Item item) => await _items.ReplaceOneAsync(i => i.Id == id, item);

    public async Task DeleteAsync(string id) => await _items.DeleteOneAsync(i => i.Id == id);
}
