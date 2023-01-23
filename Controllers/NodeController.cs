using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {

        private readonly HttpClient _httpClient;

        public NodeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: api/<NodeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _httpClient.GetAsync("https://fgrg.azurewebsites.net/");

            if (!response.IsSuccessStatusCode)
            {
                // Handle error
               Console.WriteLine(response.ToString());
            }

            var data = await response.Content.ReadAsStringAsync();
            return Ok(data);
     
        }

        // GET api/<NodeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NodeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NodeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NodeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
