using CorporateMassenger.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateMessenger.Data.Mapping
{
    public sealed class Massage : BaseEntity<int>
    {
        public string TextMassage { get; set; }
        public List<UserMassage> UserMassageList { get; set; }
        public Massage()
        {
            UserMassageList = new List<UserMassage>();
        }

    }
}
