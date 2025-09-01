using Microsoft.AspNetCore.Mvc;

namespace ShoppingList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingItemController : ControllerBase
    {
        private static readonly List<ShoppingItem> Items = 
        [
            new ShoppingItem
            {
                Id = Guid.NewGuid(),
                Name = "Milk"
            },
            new ShoppingItem
            {    
                Id = Guid.NewGuid(),
                Name = "Oats"
            },
            new ShoppingItem
            {
                Id = Guid.NewGuid(),
                Name = "Onions"
            },
        ];

        private readonly ILogger<ShoppingItemController> _logger;

        public ShoppingItemController(ILogger<ShoppingItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetItems")]
        public IEnumerable<ShoppingItem> Get()
        {
            return Items;
        }

        [HttpPost(Name = "AddItem")]
        public void Add([FromBody] ShoppingItem item)
        {
            item.Id = Guid.NewGuid();
            Items.Add(item);
        }

        [HttpDelete("{id:guid}", Name = "RemoveItem")]
        public void Remove(Guid id)
        {
            Items.RemoveAll(item => item.Id == id);
        }
    }
}
