using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace firstWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        private readonly DataContext _context;

        public HelloController(DataContext context)
        {
            _context = context;
        }
        

        [HttpGet]
        public async Task<ActionResult<List<firstWeb>>> Get()
        { 
            return Ok(await _context.firstWebs.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<firstWeb>> Get(int id)
        {
            var hero = await _context.firstWebs.FindAsync(id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<firstWeb>>> AddHero (firstWeb hero)
        {
            _context.firstWebs.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.firstWebs.ToListAsync());
       
 }
        [HttpPut]
        public async Task<ActionResult<List<firstWeb>>> UpdateHero(firstWeb request)
        {
            var dbhero = await _context.firstWebs.FindAsync(request.Id);
            if (dbhero == null)
                return BadRequest("Hero not found.");

            dbhero.Name = request.Name;
            dbhero.FirstName = request.FirstName;
            dbhero.LastName = request.LastName;
            dbhero.Place = request.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.firstWebs.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<firstWeb>>> Delete(int id)
        {
            var dbhero = await _context.firstWebs.FindAsync(id);
            if (dbhero == null)
                return BadRequest("Hero not found.");

            _context.firstWebs.Remove(dbhero);
            await _context.SaveChangesAsync();

            return Ok(await _context.firstWebs.ToListAsync());
        }

    }
}
