using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateMessenger.Data.Mapping
{
    public abstract class BaseEntity
    {

    }

    public abstract class BaseEntity<T> : BaseEntity
    {
        public T Id { get; set; }
    }
}
