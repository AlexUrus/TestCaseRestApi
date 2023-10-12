using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCaseRestApi.Data;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillBlockController : ControllerBase
    {
        private readonly AppDataContext _context;

        public DrillBlockController(AppDataContext context)
        {
            _context = context;
        }

        // GET api/DrillBlock
        [HttpGet]
        public JsonResult Get()
        {
            var drillBlocks = _context.DrillBlocks.ToList();
            return new JsonResult( Ok(drillBlocks));
        }

        // GET api/DrillBlock/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var drillBlock = _context.DrillBlocks.Find(id);
            if (drillBlock == null)
                return new JsonResult(NotFound());

            return  new JsonResult(Ok(drillBlock));
        }

        // POST api/DrillBlock
        [HttpPost]
        public JsonResult Post(DrillBlock drillBlock)
        {
            _context.DrillBlocks.Add(drillBlock);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }

        // PUT api/DrillBlock/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, DrillBlock drillBlock)
        {
            if (id != drillBlock.Id)
                return new JsonResult(BadRequest());

            var existingDrillBlock = _context.DrillBlocks.Find(id);
            if (existingDrillBlock == null)
                return new JsonResult(NotFound());

            existingDrillBlock.Name = drillBlock.Name;
            existingDrillBlock.UpdateTime = drillBlock.UpdateTime;

            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        // DELETE api/DrillBlock/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var drillBlock = _context.DrillBlocks.Find(id);
            if (drillBlock == null)
                return new JsonResult(NotFound());

            _context.DrillBlocks.Remove(drillBlock);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
    }
}
