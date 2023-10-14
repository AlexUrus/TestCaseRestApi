using Microsoft.EntityFrameworkCore;
using TestCaseRestApi.Data;
using TestCaseRestApi.Mappers;
using TestCaseRestApi.Models;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Repositories
{
    public class HoleRepository : IRepository<HoleModel>
    {
        private readonly HoleMapper _mapper;
        private readonly AppDataContext _context;

        public HoleRepository(AppDataContext context)
        {
            _context = context;
            _mapper = new HoleMapper();
        }

        public void Add(HoleModel model)
        {
            _context.Holes.Add(_mapper.ToObject(model));
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Holes.Find(id);
            if (entity != null)
            {
                _context.Holes.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<HoleModel> GetAll()
        {
            var listObjects = _context.Holes.ToList();
            var listModels = new List<HoleModel>();
            foreach (var obj in listObjects)
            {
                listModels.Add(_mapper.ToModel(obj));
            }
            return listModels;
        }

        public HoleModel GetById(int id)
        {
            return _mapper.ToModel(_context.Holes.Find(id));
        }

        public void Update(HoleModel model)
        {
            _context.Holes.Update(_mapper.ToObject(model));
            _context.SaveChanges();
        }
    }
}
