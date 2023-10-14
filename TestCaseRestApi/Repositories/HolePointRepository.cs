using TestCaseRestApi.Data;
using TestCaseRestApi.Mappers;
using TestCaseRestApi.Models;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Repositories
{
    public class HolePointRepository : IRepository<HolePointModel>
    {
        private readonly HolePointMapper _mapper;
        private readonly AppDataContext _context;

        public HolePointRepository(AppDataContext context)
        {
            _context = context;
            _mapper = new HolePointMapper();
        }

        public void Add(HolePointModel model)
        {
            _context.HolePoints.Add(_mapper.ToObject(model));
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.HolePoints.Find(id);
            if (entity != null)
            {
                _context.HolePoints.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<HolePointModel> GetAll()
        {
            var listObjects = _context.HolePoints.ToList();
            var listModels = new List<HolePointModel>();
            foreach (var obj in listObjects)
            {
                listModels.Add(_mapper.ToModel(obj));
            }
            return listModels;
        }

        public HolePointModel GetById(int id)
        {
            return _mapper.ToModel(_context.HolePoints.Find(id));
        }

        public void Update(HolePointModel model)
        {
            _context.HolePoints.Update(_mapper.ToObject(model));
            _context.SaveChanges();
        }
    }
}
