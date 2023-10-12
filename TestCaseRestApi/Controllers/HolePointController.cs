using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCaseRestApi.Data;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolePointController : ControllerBase
    {
        private readonly AppDataContext _context;

        public HolePointController(AppDataContext context)
        {
            _context = context;
        }

        // GET api/HolePoint
        [HttpGet]
        public JsonResult Get()
        {
            var holePoints = _context.HolePoints.ToList();
            return new JsonResult(holePoints);
        }

        // GET api/HolePoint/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var holePoint = _context.HolePoints.Find(id);
            if (holePoint == null)
                return new JsonResult(NotFound());

            return new JsonResult(holePoint);
        }

        // POST api/HolePoint
        [HttpPost]
        public JsonResult Post([FromBody] HolePoint holePoint)
        {
            _context.HolePoints.Add(holePoint);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }

        // PUT api/HolePoint/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] HolePoint holePoint)
        {
            if (id != holePoint.Id)
                return new JsonResult(BadRequest());

            var existingHolePoint = _context.HolePoints.Find(id);
            if (existingHolePoint == null)
                return new JsonResult(NotFound());

            existingHolePoint.Hole = holePoint.Hole;
            existingHolePoint.X = holePoint.X;
            existingHolePoint.Y = holePoint.Y;
            existingHolePoint.Z = holePoint.Z;

            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        // DELETE api/HolePoint/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var holePoint = _context.HolePoints.Find(id);
            if (holePoint == null)
                return new JsonResult(NotFound());

            _context.HolePoints.Remove(holePoint);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
    }
}
