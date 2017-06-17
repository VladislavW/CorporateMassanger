using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporateMessenger.Data.Interfaces;
using CorporateMassenger.Data;
using CorporateMessenger.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CorporateMessenger.Data.Repository
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity: BaseEntity<int>
    {

        protected readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual IQueryable<TEntity> Source => _context.Set<TEntity>(); 

        public void Add(TEntity entyty)
        {
             _context.Set<TEntity>().Add(entyty);
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await _context.Set<TEntity>().FirstAsync(item => item.Id == id);

        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
