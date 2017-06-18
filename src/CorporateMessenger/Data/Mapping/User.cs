using CorporateMessenger.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateMassenger.Data.Mapping
{
    public sealed class User : BaseEntity<int>
    {
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }

        public Groups Groups { get; set; }
        public Role Role { get; set; }

        public List<UserMessage> UserMassageList { get; set; }
        public User()
        {
            UserMassageList = new List<UserMessage>();
        }


    }
}
