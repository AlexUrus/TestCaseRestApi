using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCaseRestApi.Data;
using TestCaseRestApi.Models;

namespace TestCaseRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AppDataContext _context;

        public ValuesController(AppDataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult CreateHole(Hole hole)
        {
            if(hole.Id == 0)
            {
                _context.Holes.Add(hole);
            }
            else
            {
                var holeInDb = _context.Holes.Find(hole.Id);

                if (holeInDb == null)
                    return new JsonResult(NotFound());

            }
            _context.SaveChanges();
            return new JsonResult(Ok(hole));
        }
    }
}
