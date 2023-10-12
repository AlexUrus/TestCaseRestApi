using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCaseRestApi.Data;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoleController : ControllerBase
    {
        private readonly AppDataContext _context;

        public HoleController(AppDataContext context)
        {
            _context = context;
        }

        // GET api/Hole
        [HttpGet]
        public JsonResult Get()
        {
            var holes = _context.Holes.ToList();
            return new JsonResult(holes);
        }

        // GET api/Hole/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var hole = _context.Holes.Find(id);
            if (hole == null)
                return new JsonResult(NotFound());

            return new JsonResult(hole);
        }

        // POST api/Hole
        [HttpPost]
        public JsonResult Post([FromBody] Hole hole)
        {
            _context.Holes.Add(hole);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }

        // PUT api/Hole/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] Hole hole)
        {
            if (id != hole.Id)
                return new JsonResult(BadRequest());

            var existingHole = _context.Holes.Find(id);
            if (existingHole == null)
                return new JsonResult(NotFound());

            existingHole.Name = hole.Name;
            existingHole.DrillBlock = hole.DrillBlock;
            existingHole.Depth = hole.Depth;

            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        // DELETE api/Hole/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var hole = _context.Holes.Find(id);
            if (hole == null)
                return new JsonResult(NotFound());

            _context.Holes.Remove(hole);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
    }
}
