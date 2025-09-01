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
                Name = "Milk"
            },
            new ShoppingItem
            {
                Name = "Oats"
            },
            new ShoppingItem
            {
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
        public void Add([FromBody] ShoppingItem name)
        {
            Items.Add(name);
        }
    }
}
