using TestCaseRestApi.Data;
using TestCaseRestApi.Mappers;
using TestCaseRestApi.Models;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Repositories
{
    public class DrillBlockRepository : IRepository<DrillBlockModel>
    {
        private readonly DrillBlockMapper _mapper;
        private readonly AppDataContext _context;

        public DrillBlockRepository(AppDataContext context)
        {
            _context = context;
            _mapper = new DrillBlockMapper();
        }

        public void Add(DrillBlockModel drillBlockModel)
        {
            _context.DrillBlocks.Add(_mapper.ToObject(drillBlockModel));
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var drillBlock = _context.DrillBlocks.Find(id);
            if (drillBlock != null)
            {
                _context.DrillBlocks.Remove(drillBlock);
                _context.SaveChanges();
            }
        }

        public List<DrillBlockModel> GetAll()
        {
            var drillBlocks = _context.DrillBlocks.ToList();
            var drillBlockModels = new List<DrillBlockModel>();
            foreach (var drillBlock in drillBlocks)
            {
                drillBlockModels.Add(_mapper.ToModel(drillBlock));
            }
            return drillBlockModels;
        }

        public DrillBlockModel GetById(int id)
        {
            return _mapper.ToModel( _context.DrillBlocks.Find(id));
        }

        public void Update(DrillBlockModel drillBlockModel)
        {
            _context.DrillBlocks.Update(_mapper.ToObject(drillBlockModel));
            _context.SaveChanges();
        }

        
    }

}
