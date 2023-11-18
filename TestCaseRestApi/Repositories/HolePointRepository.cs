using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;
using TestCaseRestApi.CustomException;
using TestCaseRestApi.Data;
using TestCaseRestApi.Models;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Repositories
{
    public class HolePointRepository : IRepository<HolePointModel>
    {
        private readonly IMapper _mapper;
        private readonly AppDataContext _context;
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public HolePointRepository(AppDataContext context, IMapper mapper)
        { 
            _context = context;
            _mapper = mapper;
        }

        public void Add(HolePointModel model)
        {
            try
            {
                _context.HolePoints.Add(_mapper.Map<HolePoint>(model));
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.Error(ex);
                throw new HolePointRepositoryException("Ошибка при добавлении элемента.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var entity = _context.HolePoints.Find(id);
                if (entity != null)
                {
                    _context.HolePoints.Remove(entity);
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.Error(ex);
                throw new HolePointRepositoryException("Ошибка при удалении элемента.", ex);
            }
        }

        public List<HolePointModel> GetAll()
        {
            try
            {
                var listObjects = _context.HolePoints.Include(hp => hp.Hole.DrillBlock).ToList();
                var listModels = new List<HolePointModel>();
                foreach (var obj in listObjects)
                {
                    listModels.Add(_mapper.Map<HolePointModel>(obj));
                }
                return listModels;
            }
            catch (DbUpdateException ex)
            {
                _logger.Error(ex);
                throw new HolePointRepositoryException("Ошибка при получении всех элементов.", ex);
            }
        }

        public HolePointModel? GetById(int id)
        {
            try
            {
                var obj = _context.HolePoints.Find(id);

                if (obj != null)
                    return _mapper.Map<HolePointModel>(obj);
                else
                    return null;
            }
            catch (DbUpdateException ex)
            {
                _logger.Error(ex);
                throw new HolePointRepositoryException("Ошибка при получении элемента по ID.", ex);
            }
        }

        public void Update(HolePointModel model)
        {
            try
            {
                var existingObj = _context.HolePoints.Find(model.Id);

                if (model.HoleModel != null)
                    existingObj.HoleId = model.HoleModel.Id;

                if (model.Point != null)
                {
                    existingObj.X = model.Point.X;
                    existingObj.Y = model.Point.Y;
                    existingObj.Z = model.Point.Z;
                }

                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.Error(ex);
                throw new HolePointRepositoryException("Ошибка при обновлении элемента.", ex);
            }
        }
    }
}
