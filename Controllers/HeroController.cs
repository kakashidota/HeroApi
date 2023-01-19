using HeroApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {

        private static List<Hero> _heroes = new List<Hero>()
        {
            new Hero(){Id=1, Name="Tony Stark", Team="Avengers", SuperHeroName="IronMan"}, 
            new Hero(){Name="Peter parker", Id=2, SuperHeroName="Spiderman", Team="Marvel"}
        };



        // GET: api/<HeroController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_heroes);
        }

        // GET api/<HeroController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_heroes.FirstOrDefault(x => x.Id == id));
        }

        // POST api/<HeroController>
        [HttpPost]
        public IActionResult Post(Hero hero)
        {
            _heroes.Add(hero);
            return Ok();
        }

        // PUT api/<HeroController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Hero hero)
        {

            var heroToUpdate = _heroes.FirstOrDefault(x => x.Id == hero.Id);
            if(heroToUpdate == null)
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
        public IActionResult Delete(int id)
        {

            var hero = _heroes.FirstOrDefault(x => x.Id == id);
            if (hero == null)
            {
                return NotFound();
            }

            _heroes.Remove(hero);
            return Ok();

        }
    }
}
