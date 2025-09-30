using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<ShoppingItem> Get()
        {
            return _context.ShoppingItems.ToList();
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
        public void Add([FromBody] ShoppingItem item)
        {
            item.Id = Guid.NewGuid();
            _context.ShoppingItems.Add(item);
            _context.SaveChanges();
        }

        [HttpDelete("{id:guid}", Name = "RemoveItem")]
        public void Remove(Guid id)
        {
            var itemToDelete = _context.ShoppingItems.SingleOrDefault(item => item.Id == id);

            if (itemToDelete == null)
            {
                return;
            }
           
            _context.ShoppingItems.Remove(itemToDelete);
            _context.SaveChanges();
        }
    }
}
