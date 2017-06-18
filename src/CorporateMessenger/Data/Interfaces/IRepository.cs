using CorporateMessenger.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateMessenger.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity<int>
    {
        Task<T> FindAsync(int id);
        void Add(T entyty);
        void Remove(T entity);
        void Update(T entyty);

        Task<List<T>> GetAll();

        IQueryable<T> Source { get; }

        void SaveChanges();
    }
}
