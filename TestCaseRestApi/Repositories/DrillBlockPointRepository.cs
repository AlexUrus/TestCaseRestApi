using Microsoft.EntityFrameworkCore;
using TestCaseRestApi.CustomException;
using TestCaseRestApi.Data;
using TestCaseRestApi.Mappers.Object_Model;
using TestCaseRestApi.Models;

namespace TestCaseRestApi.Repositories
{
    public class DrillBlockPointRepository : IRepository<DrillBlockPointModel>
    {
        private readonly DrillBlockPointMapperOM _mapper;
        private readonly AppDataContext _context;

        public DrillBlockPointRepository(AppDataContext context)
        {
            _context = context;
            _mapper = new DrillBlockPointMapperOM();
        }

        public void Add(DrillBlockPointModel model)
        {
            try
            {
                _context.DrillBlockPoints.Add(_mapper.ToObject(model));
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            { 
                throw new DrillBlockPointRepositoryException("Ошибка при добавлении элемента.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var entity = _context.DrillBlockPoints.Find(id);
                if (entity != null)
                {
                    _context.DrillBlockPoints.Remove(entity);
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new DrillBlockPointRepositoryException("Ошибка при удалении элемента.", ex);
            }
        }

        public List<DrillBlockPointModel> GetAll()
        {
            try
            {
                var listObjects = _context.DrillBlockPoints.ToList();
                var listModels = new List<DrillBlockPointModel>();
                foreach (var obj in listObjects)
                {
                    listModels.Add(_mapper.ToModel(obj));
                }
                return listModels;
            }
            catch (Exception ex)
            {
                throw new DrillBlockPointRepositoryException("Ошибка при получении всех элементов.", ex);
            }
        }

        public DrillBlockPointModel? GetById(int id)
        {
            try
            {
                var obj = _context.DrillBlockPoints.Find(id);

                if (obj != null)
                    return _mapper.ToModel(obj);
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new DrillBlockPointRepositoryException("Ошибка при получении элемента по ID.", ex);
            }
        }

        public void Update(DrillBlockPointModel model)
        {
            try
            {
                var existingObj = _context.DrillBlockPoints.Find(model.Id);

                if (model.DrillBlockModel != null)
                    existingObj.DrillBlockId = model.DrillBlockModel.Id;

                if (model.Point != null)
                {
                    existingObj.X = model.Point.X;
                    existingObj.Y = model.Point.Y;
                    existingObj.Z = model.Point.Z;
                }

                existingObj.Sequence = model.Sequence;

                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DrillBlockPointRepositoryException("Ошибка при обновлении элемента.", ex);
            }
        }
    }
}
