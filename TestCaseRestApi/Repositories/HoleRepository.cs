﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;
using TestCaseRestApi.CustomException;
using TestCaseRestApi.Data;
using TestCaseRestApi.Models;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Repositories
{
    public class HoleRepository : IRepository<HoleModel>
    {
        private readonly IMapper _mapper;
        private readonly AppDataContext _context;
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public HoleRepository(AppDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(HoleModel model)
        {
            try
            {
                _context.Holes.Add(_mapper.Map<Hole>(model));
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.Error(ex);
                throw new HoleRepositoryException("Ошибка при добавлении элемента.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var entity = _context.Holes.Find(id);
                if (entity != null)
                {
                    _context.Holes.Remove(entity);
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.Error(ex);
                throw new HoleRepositoryException("Ошибка при удалении элемента.", ex);
            }
        }

        public List<HoleModel> GetAll()
        {
            try
            {
                var listObjects = _context.Holes.Include(h => h.DrillBlock).ToList();
                var listModels = new List<HoleModel>();
                foreach (var obj in listObjects)
                {
                    listModels.Add(_mapper.Map<HoleModel>(obj));
                }
                return listModels;
            }
            catch (DbUpdateException ex)
            {
                _logger.Error(ex);
                throw new HoleRepositoryException("Ошибка при получении всех элементов.", ex);
            }
        }

        public HoleModel? GetById(int id)
        {
            try
            {
                var obj = _context.Holes.Find(id);

                if (obj != null)
                    return _mapper.Map<HoleModel>(obj);
                else
                    return null;
            }
            catch (DbUpdateException ex)
            {
                _logger.Error(ex);
                throw new HoleRepositoryException("Ошибка при получении элемента по ID.", ex);
            }
        }

        public void Update(HoleModel model)
        {
            try
            {
                var existingObj = _context.Holes.Find(model.Id);
                existingObj.Name = model.Name;
                existingObj.Depth = model.Depth;

                if (model.DrillBlockModel != null)
                    existingObj.DrillBlockId = model.DrillBlockModel.Id;

                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.Error(ex);
                throw new HoleRepositoryException("Ошибка при обновлении элемента.", ex);
            }
        }
    }
}
