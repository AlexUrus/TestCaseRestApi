using TestCaseRestApi.Data;
using TestCaseRestApi.Mappers;
using TestCaseRestApi.Models;

namespace TestCaseRestApi.Repositories
{
    public class DrillBlockPointRepository : IRepository<DrillBlockPointModel>
    {
        private readonly DrillBlockPointMapper _mapper;
        private readonly AppDataContext _context;

        public DrillBlockPointRepository(AppDataContext context)
        {
            _context = context;
            _mapper = new DrillBlockPointMapper();
        }

        public void Add(DrillBlockPointModel model)
        {
            _context.DrillBlockPoints.Add(_mapper.ToObject(model));
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.DrillBlockPoints.Find(id);
            if (entity != null)
            {
                _context.DrillBlockPoints.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<DrillBlockPointModel> GetAll()
        {
            var listObjects = _context.DrillBlockPoints.ToList();
            var listModels = new List<DrillBlockPointModel>();
            foreach (var obj in listObjects)
            {
                listModels.Add(_mapper.ToModel(obj));
            }
            return listModels;
        }

        public DrillBlockPointModel GetById(int id)
        {
            return _mapper.ToModel(_context.DrillBlockPoints.Find(id));
        }

        public void Update(DrillBlockPointModel model)
        {
            _context.DrillBlockPoints.Update(_mapper.ToObject(model));
            _context.SaveChanges();
        }
    }
}
