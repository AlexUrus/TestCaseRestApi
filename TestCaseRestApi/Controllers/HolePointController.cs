﻿using Microsoft.AspNetCore.Mvc;
using NLog;
using TestCaseRestApi.Mappers.DTO_Model;
using TestCaseRestApi.ModelsDTO;
using TestCaseRestApi.Repositories;

namespace TestCaseRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolePointController : ControllerBase
    {
        private readonly HolePointRepository _repository;
        private readonly HolePointMapperDM _mapper;
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public HolePointController(HolePointRepository repository)
        {
            _repository = repository;
            _mapper = new HolePointMapperDM();
        }

        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                var models = _repository.GetAll();

                var modelDTOs = new List<HolePointModelDTO>();
                foreach (var model in models)
                {
                    modelDTOs.Add(_mapper.ToModelDTO(model));
                }

                return new JsonResult(Ok(modelDTOs));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new JsonResult(new { error = ex.Message })
                {
                    StatusCode = 500
                };
            }
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                var model = _repository.GetById(id);
                if (model == null)
                    return new JsonResult(NotFound());

                return new JsonResult(Ok(model));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new JsonResult(new { error = ex.Message })
                {
                    StatusCode = 500
                };
            }
        }

        [HttpPost]
        public JsonResult Post(HolePointModelDTO modelDTO)
        {
            try
            {
                var model = _mapper.ToModel(modelDTO);
                _repository.Add(model);
                return new JsonResult(NoContent());
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new JsonResult(new { error = ex.Message })
                {
                    StatusCode = 500
                };
            }
        }

        [HttpPut("{id}")]
        public JsonResult Put(int id, HolePointModelDTO modelDTO)
        {
            try
            {
                if (id != modelDTO.Id)
                    return new JsonResult(BadRequest());

                var existingModel = _repository.GetById(id);
                if (existingModel == null)
                    return new JsonResult(NotFound());

                _repository.Update(existingModel);

                return new JsonResult(NoContent());
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new JsonResult(new { error = ex.Message })
                {
                    StatusCode = 500
                };
            }
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                var model = _repository.GetById(id);
                if (model == null)
                    return new JsonResult(NotFound());

                _repository.Delete(id);
                return new JsonResult(NoContent());
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new JsonResult(new { error = ex.Message })
                {
                    StatusCode = 500
                };
            }
        }
    }
}
