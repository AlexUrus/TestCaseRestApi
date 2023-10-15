using Microsoft.EntityFrameworkCore;
using TestCaseRestApi.Mappers;
using TestCaseRestApi.Models;
using TestCaseRestApi.Objects;

namespace TestCaseRestApi.Repositories
{
    public interface IRepository<T> where T : AbstractModel
    {
        public List<T> GetAll();
        public T? GetById(int id);
        public void Add(T model);
        public void Update(T model);
        public void Delete(int id);
    }
}
