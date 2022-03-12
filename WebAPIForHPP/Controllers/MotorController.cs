using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIForHPP.Models;

namespace WebAPIForHPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorController : ControllerBase
    {
        private readonly DataContext _context;
        public MotorController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetMotor()
        {
            return Ok(await _context.Motors.ToListAsync());
        }
        
        [HttpPost]
        public async Task<ActionResult<List<Motor>>> AddMotor(Motor motor)
        {
            _context.Motors.Add(motor);
            await _context.SaveChangesAsync();
            return Ok(await _context.Motors.ToListAsync());
        }
    }
}
