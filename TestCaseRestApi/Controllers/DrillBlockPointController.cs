using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCaseRestApi.Data;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillBlockPointController : ControllerBase
    {
        private readonly AppDataContext _context;

        public DrillBlockPointController(AppDataContext context)
        {
            _context = context;
        }

        // GET api/DrillBlockPoint
        [HttpGet]
        public JsonResult Get()
        {
            var drillBlockPoints = _context.DrillBlockPoints.ToList();
            return new JsonResult(drillBlockPoints);
        }

        // GET api/DrillBlockPoint/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var drillBlockPoint = _context.DrillBlockPoints.Find(id);
            if (drillBlockPoint == null)
                return new JsonResult(NotFound());

            return new JsonResult(drillBlockPoint);
        }

        // POST api/DrillBlockPoint
        [HttpPost]
        public JsonResult Post([FromBody] DrillBlockPoint drillBlockPoint)
        {
            _context.DrillBlockPoints.Add(drillBlockPoint);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }

        // PUT api/DrillBlockPoint/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] DrillBlockPoint drillBlockPoint)
        {
            if (id != drillBlockPoint.Id)
                return new JsonResult(BadRequest());

            var existingDrillBlockPoint = _context.DrillBlockPoints.Find(id);
            if (existingDrillBlockPoint == null)
                return new JsonResult(NotFound());

            existingDrillBlockPoint.DrillBlock = drillBlockPoint.DrillBlock;
            existingDrillBlockPoint.Sequence = drillBlockPoint.Sequence;
            existingDrillBlockPoint.X = drillBlockPoint.X;
            existingDrillBlockPoint.Y = drillBlockPoint.Y;
            existingDrillBlockPoint.Z = drillBlockPoint.Z;

            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        // DELETE api/DrillBlockPoint/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var drillBlockPoint = _context.DrillBlockPoints.Find(id);
            if (drillBlockPoint == null)
                return new JsonResult(NotFound());

            _context.DrillBlockPoints.Remove(drillBlockPoint);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
    }
}
