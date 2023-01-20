using HeroApi.Data;
using HeroApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroController : ControllerBase
    {

        private readonly ApiDbContext _context;

        public HeroController(ApiDbContext context)
        {
            _context = context;
        }


        // GET: api/<HeroController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Heroes.ToListAsync());
        }

        // GET api/<HeroController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var hero = await _context.Heroes.FirstOrDefaultAsync(x => x.Id == id);


            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        // POST api/<HeroController>
        [HttpPost]
        public async Task<IActionResult> Post(Hero hero)
        {
            _context.Heroes.Add(hero);

            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<HeroController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Hero hero)
        {

            var heroToUpdate = await _context.Heroes.FirstOrDefaultAsync(x => x.Id == hero.Id);
            if (heroToUpdate == null)
            {
                return NotFound();
            }

            heroToUpdate.Name = hero.Name;
            heroToUpdate.Team = hero.Team;
            heroToUpdate.SuperHeroName = hero.SuperHeroName;

            return Ok();
        }

        // DELETE api/<HeroController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var hero = _context.Heroes.FirstOrDefault(x => x.Id == id);
            if (hero == null)
            {
                return NotFound();
            }

            _context.Heroes.Remove(hero);

            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
