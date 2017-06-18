using CorporateMassenger.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateMessenger.Data.Mapping
{
    public sealed class Role : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
