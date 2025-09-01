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
            Items.Add(item);
        }

        [HttpDelete(Name = "RemoveItem")]
        public void Remove([FromBody] ShoppingItem removedItem)
        {
            Items.RemoveAll(item => item.Name == removedItem.Name);
        }
    }
}
