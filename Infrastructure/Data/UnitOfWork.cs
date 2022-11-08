using System.Collections;
using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FurnitureStoreContext _context;
        private Hashtable _repositories;
        public UnitOfWork(FurnitureStoreContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            if(_repositories == null) _repositories = new Hashtable();

            var type = typeof(T).Name;

            if(!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);

                _repositories.Add(type, repositoryInstance);
            }
            return (IRepository<T>) _repositories[type];
        }
    }
}