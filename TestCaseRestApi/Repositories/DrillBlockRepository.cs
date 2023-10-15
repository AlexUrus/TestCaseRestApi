using Microsoft.EntityFrameworkCore;
using TestCaseRestApi.CustomException;
using TestCaseRestApi.Data;
using TestCaseRestApi.Mappers.Object_Model;
using TestCaseRestApi.Models;

namespace TestCaseRestApi.Repositories
{
    public class DrillBlockRepository : IRepository<DrillBlockModel>
    {
        private readonly DrillBlockMapperOM _mapper;
        private readonly AppDataContext _context;

        public DrillBlockRepository(AppDataContext context)
        {
            _context = context;
            _mapper = new DrillBlockMapperOM();
        }

        public void Add(DrillBlockModel model)
        {
            try
            {
                _context.DrillBlocks.Add(_mapper.ToObject(model));
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DrillBlockRepositoryException("Ошибка при добавлении элемента.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var entity = _context.DrillBlocks.Find(id);
                if (entity != null)
                {
                    _context.DrillBlocks.Remove(entity);
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new DrillBlockRepositoryException("Ошибка при удалении элемента.", ex);
            }
        }


        public List<DrillBlockModel> GetAll()
        {
            try
            {
                var listObjects = _context.DrillBlocks.ToList();
                var listModels = new List<DrillBlockModel>();
                foreach (var obj in listObjects)
                {
                    listModels.Add(_mapper.ToModel(obj));
                }
                return listModels;
            }
            catch (Exception ex)
            {
                throw new DrillBlockRepositoryException("Ошибка при получении всех элементов.", ex);
            }
        }

        public DrillBlockModel? GetById(int id)
        {
            try
            {
                var obj = _context.DrillBlocks.Find(id);

                if (obj != null)
                    return _mapper.ToModel(obj);
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new DrillBlockRepositoryException("Ошибка при получении элемента по ID.", ex);
            }
        }

        public void Update(DrillBlockModel drillBlockModel)
        {
            try
            {
                var existingObj = _context.DrillBlocks.Find(drillBlockModel.Id);
                existingObj.Name = drillBlockModel.Name;
                existingObj.UpdateTime = DateTime.UtcNow;
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DrillBlockRepositoryException("Ошибка при обновлении элемента.", ex);
            }
        }

        
    }

}
