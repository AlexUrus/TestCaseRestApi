using Microsoft.EntityFrameworkCore;
using TestCaseRestApi.CustomException;
using TestCaseRestApi.Data;
using TestCaseRestApi.Mappers.Object_Model;
using TestCaseRestApi.Models;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Repositories
{
    public class HoleRepository : IRepository<HoleModel>
    {
        private readonly HoleMapperOM _mapper;
        private readonly AppDataContext _context;

        public HoleRepository(AppDataContext context)
        {
            _context = context;
            _mapper = new HoleMapperOM();
        }

        public void Add(HoleModel model)
        {
            try
            {
                _context.Holes.Add(_mapper.ToObject(model));
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
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
                    listModels.Add(_mapper.ToModel(obj));
                }
                return listModels;
            }
            catch (DbUpdateException ex)
            {
                throw new HoleRepositoryException("Ошибка при получении всех элементов.", ex);
            }
        }

        public HoleModel? GetById(int id)
        {
            try
            {
                var obj = _context.Holes.Find(id);

                if (obj != null)
                    return _mapper.ToModel(obj);
                else
                    return null;
            }
            catch (DbUpdateException ex)
            {
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
                throw new HoleRepositoryException("Ошибка при обновлении элемента.", ex);
            }
        }
    }
}
