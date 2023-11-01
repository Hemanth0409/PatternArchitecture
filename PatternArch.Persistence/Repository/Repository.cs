using Microsoft.EntityFrameworkCore;
using PatternArch.Persistence.IRepository;
using PatternArch.Persistence.Models;

#nullable disable
namespace PatternArch.Persistence.Repository
{

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataCheckContext _context;
        private readonly DbSet<T> _data;
        public Repository(DataCheckContext context)
        {
            _context = context;
            _data = context.Set<T>();
        }
        public void Add(T entity)
        {
            _data.Add(entity);
            _context.SaveChanges();

        }

        public void Delete(T entity)
        {
            _data.Remove(entity);
            _context.SaveChanges();

        }

        public IEnumerable<T> GetAll()
        {
            return _data.AsEnumerable();
        }

        public T GetById(int id)
        {
          return  _data.Find(id);
        }

        public void Update(T entity)
        {
            _data.Update(entity);
            _context.SaveChanges();
        }
    }
}
