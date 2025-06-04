[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly ItemService _service;

    public ItemsController(ItemService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<List<Item>>> Get() => await _service.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> Get(string id)
    {
        var item = await _service.GetAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult> Post(Item item)
    {
        await _service.CreateAsync(item);
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(string id, Item item)
    {
        var existing = await _service.GetAsync(id);
        if (existing is null) return NotFound();

        item.Id = id;
        await _service.UpdateAsync(id, item);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        var item = await _service.GetAsync(id);
        if (item is null) return NotFound();

        await _service.DeleteAsync(id);
        return NoContent();
    }
}
