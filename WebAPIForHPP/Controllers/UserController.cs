using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIForHPP.Models;

namespace WebAPIForHPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> GetUser([FromBody] User RecivedUser)
        {
            IActionResult result = BadRequest();
            User SendUser = new User();
            List<User> users = new List<User>();
            users = await _context.Users.ToListAsync();
            var SelectedUser = from user in users
                               where user.Name == RecivedUser.Name
                               select user;
            foreach (User user in SelectedUser)
            {
                SendUser = user;
                result = Ok(SendUser);
            }
                return result;
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());

        }
    }
}
