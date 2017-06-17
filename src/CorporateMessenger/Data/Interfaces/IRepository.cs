using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateMessenger.Data.Interfaces
{
    public interface IRepository<T> where T : 
    {
        Task<T> FindAsync(int id);
        void Add(T entyty);
        void Remove(IEnumerable<T> entities);
    }
}
