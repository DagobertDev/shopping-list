using Microsoft.AspNetCore.Mvc;

namespace ShoppingList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingItemController : ControllerBase
    {
        private static readonly List<string> Items = 
        [
            "Milk", "Oats", "Onions"
        ];

        private readonly ILogger<ShoppingItemController> _logger;

        public ShoppingItemController(ILogger<ShoppingItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetItems")]
        public IEnumerable<ShoppingItem> Get()
        {
            return Items.Select(item => new ShoppingItem 
            { 
                Name = item
            })
            .ToArray();
        }

        [HttpPost(Name = "AddItem")]
        public void Add([FromBody] string name)
        {
            Items.Add(name);
        }
    }
}
