using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ShoppingList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingItemController : ControllerBase
    {
        private readonly ShoppingListContext _context;
        private readonly ILogger<ShoppingItemController> _logger;

        public ShoppingItemController(ShoppingListContext context, ILogger<ShoppingItemController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet(Name = "GetItems")]
        public async Task<ActionResult<IEnumerable<ShoppingItem>>> Get()
        {
            return await _context.ShoppingItems.ToListAsync();
        }

        [HttpGet("{id:guid}", Name = "GetItem")]
        public async Task<ActionResult<ShoppingItem>> GetById(Guid id)
        {
            var item = await _context.ShoppingItems.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost(Name = "AddItem")]
        public async Task<IActionResult> Add([FromBody] ShoppingItem item)
        {
            item.Id = Guid.NewGuid();
            _context.ShoppingItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpDelete("{id:guid}", Name = "RemoveItem")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var itemToDelete = await _context.ShoppingItems.SingleOrDefaultAsync(item => item.Id == id);

            if (itemToDelete == null)
            {
                return NotFound();
            }

            _context.ShoppingItems.Remove(itemToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
