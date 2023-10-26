using Halloween.Repo.DTO;
using Halloween.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Halloween.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        ITeamRepo repo { get; }
        public TeamController(ITeamRepo r)
        {
            repo = r;
        }
        // GET: api/<TeamController>
        [HttpGet("GetAllWithoutHero")]
        public async Task<ActionResult> GetAllWithoutHero()
        {
            var result = await repo.GetAllWithoutHero();
            return Ok(result);
        }

        // POST api/<TeamController>
        [HttpPost("withHero")]
        public void CreateWithHero(Team team)
        {
            // without try etc...
            repo.CreateWithHero(team);
        }
        [HttpPost("withoutHero")]
        public void CreateWithoutHero(Team team)
        {
            repo.CreateWithoutHero(team);
        }
        /*
        // GET api/<TeamController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TeamController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TeamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
