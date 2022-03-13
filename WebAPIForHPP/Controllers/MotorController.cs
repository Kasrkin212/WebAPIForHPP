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
        [HttpPut]
        public async Task<ActionResult<List<Motor>>> ChangeMotor(Motor motor)
        {
            var DBmotor = await _context.Motors.FindAsync(motor.ID);
            if (DBmotor == null)
                return BadRequest("Motor not found.");
            DBmotor.Comment = motor.Comment;
            await _context.SaveChangesAsync();
            return Ok(await _context.Motors.ToListAsync());
        }
    }
}
