using CorporateMassenger.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateMessenger.Data.Mapping
{
    public sealed class Groups : BaseEntity<int>
    {
        public string GroupName { get; set; }
        public List<User> UserList { get; set; }
        public Groups()
        {
            UserList = new List<User>();
        }
    }
}
