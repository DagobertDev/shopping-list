using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly TokenGenerator _tokenGenerator;

        public LoginController(TokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost(Name = "Login")]
        public ActionResult<string> Login(LoginRequest request)
        {
            if (request.Password != "password")
            {
                return Unauthorized();
            }
            
            var token = _tokenGenerator.GenerateToken(request.Email);
            return token;
        }
    }
}