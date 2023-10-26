using Halloween.Repo.DTO;
using Halloween.Repo.Interfaces;
using Halloween.Repo.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Halloween.API.Controllers
{
    [Route("api/[controller]")] // URL
    [ApiController] // this is explained later - give me your best guess
    public class SuperHeroController : ControllerBase
    {
        ISuperHeroRepo SuperHeroRepo { get; }
        public SuperHeroController(ISuperHeroRepo superHeroRepo)
        {
            this.SuperHeroRepo = superHeroRepo;
        }
        #region GET

        //public async Task<List<SuperHero>> Get()
        //{
        //    return await SuperHeroRepo.GetAll();
        //}

        // GET: api/<SuperHeroController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var heroes = await SuperHeroRepo.GetAll();
                if (heroes == null)
                {
                    // something has gone wrong serverside, return code 500
                    return Problem("Unexpected null returned from service");
                }
                else if (heroes.Count == 0)
                {
                    // no data exists, but everything is still ok, return code 204
                    return NoContent();
                }
                // we got data! return with code 200
                return Ok(heroes);
            }
            catch (Exception ex)
            {
                // handle any other exeptions raised by sending code 500
                return Problem(ex.Message);
            }
        }

        [HttpGet("forskellig")]
        public int tal()
        {
            return 2222;
        }
        // GET api/<SuperHeroController>/5
        [HttpGet("{id}")]
        public SuperHero GetById(int id)
        {
            return SuperHeroRepo.GetById(id);
        }
        #endregion GET
        #region POST
        // POST api/<SuperHeroController>
        [HttpPost]
        public void Post([FromBody] SuperHero value)
        {
            SuperHeroRepo.Create(value);
        }

        // PUT api/<SuperHeroController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
        #endregion POST
        #region DELETE
        // DELETE api/<SuperHeroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SuperHeroRepo.Delete(id);
        }
        #endregion DELETE

        #region New code
        //[HttpGet("{id}")]
        //public async Task<ActionResult> GetByIdNew(int id)
        //{
        //    try
        //    {
        //        var hero = await SuperHeroRepo.GetById(id);
        //        if (hero == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(hero);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem(ex.Message);
        //    }
        //}

        //[HttpPost]
        //public async Task<ActionResult> createNew(SuperHero hero)
        //{
        //    if (hero == null) return BadRequest();
        //    var temp = await SuperHeroRepo.Create(hero);
        //    return Created("", temp);
        //}
        #endregion New code
    }
}
