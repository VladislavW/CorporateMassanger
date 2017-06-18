using CorporateMassenger.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateMessenger.Data.Mapping
{
    public sealed class Message : BaseEntity<int>
    {
        public string TextMassage { get; set; }
        public List<UserMessage> UserMassageList { get; set; }
        public Message()
        {
            UserMassageList = new List<UserMessage>();
        }

    }
}
