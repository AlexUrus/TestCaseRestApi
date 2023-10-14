using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCaseRestApi.Data;
using TestCaseRestApi.Models;
using TestCaseRestApi.Objects;
using TestCaseRestApi.Repositories;

namespace TestCaseRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillBlockController : ControllerBase
    {
        private readonly DrillBlockRepository _repository;
        public DrillBlockController(DrillBlockRepository repository)
        {
            _repository = repository;
        }

        // GET api/DrillBlockModel
        [HttpGet]
        public JsonResult Get()
        {
            var model = _repository.GetAll();
            return new JsonResult( Ok(model));
        }

        // GET api/DrillBlockModel/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var model = _repository.GetById(id);
            if (model == null)
                return new JsonResult(NotFound());

            return  new JsonResult(Ok(model));
        }

        // POST api/DrillBlockModel
        [HttpPost]
        public JsonResult Post(DrillBlockModel model)
        {
            _repository.Add(model);
            return new JsonResult(NoContent());
        }

        // PUT api/DrillBlockModel/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, DrillBlockModel model)
        {
            if (id != model.Id)
                return new JsonResult(BadRequest());

            var existingModel = _repository.GetById(id);
            if (existingModel == null)
                return new JsonResult(NotFound());

            _repository.Update(existingModel);
            
            return new JsonResult(NoContent());
        }

        // DELETE api/DrillBlockModel/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var model = _repository.GetById(id);
            if (model == null)
                return new JsonResult(NotFound());

            _repository.Delete(id);

            return new JsonResult(NoContent());
        }
    }
}
